<template>  

<div>
    
    <ProductToolbarComponent 
        v-on:showDialogProduct = "showDialogProduct"
        v-on:setIsProduct = "setIsProduct"
        v-on:btnDeleteRecord = "btnDeleteRecord"
    />
    <ProductGridComponent 
        v-bind:products ="products" 
        v-on:showDialogProduct = "showDialogProduct"
        v-on:passProductEdit = "passProductEdit"
        v-on:passIsAddOrEdit = "passIsAddOrEdit"
        v-bind:isShowLoader = "isShowLoader"
        v-on:insertProductIdToListId = "insertProductIdToListId"
        v-on:btnPaging = "btnPaging"
        v-bind:totalPage = "totalPage"
        v-bind:totalRecord = "totalRecord"
    />
    
    <ProductPopupComponent 
        v-if="showDialog"
        v-bind:productCategory = "productCategory" 
        v-on:itemComboboxClick = "itemComboboxClick"
        v-on:confirmHidedDialog = "confirmHidedDialog"
        v-bind:isAddOrEdit = "isAddOrEdit"
        v-bind:listFieldNotValidRequired = "ListFieldNotValidRequired"
        v-on:hidedDialogProduct = "hidedDialogProduct"
        v-on:showToastSuccess = "showToastSuccess"
        v-bind:productEdit = "productEdit"
        v-on:updateProduct = "updateProduct"
       
    />


    <PopupConfirmComponent 
        v-show = "isShowDialogConfirm"
        v-bind:messageConfirm = "messageConfirm"
        v-bind:isCancelSaveConfirm = "isCancelSaveConfirm"
        v-bind:isDeleteConfirm = "isDeleteConfirm"
        v-on:btnHideDialogConfirm = "btnHideDialogConfirm"
        v-on:btnNotHideDialogConfirm = "btnNotHideDialogConfirm"
        v-on:updateProduct = "updateProduct"
        v-on:btnConfirmDelete = "btnConfirmDelete"
       
    />

    
    <ToastSuccessComponent v-show = "isShowToastSuccess" v-bind:messageSuccess = "messageSuccess" />


    <PopupValidateComponent 
        v-show="isShowDialogValidate" 
        v-bind:messageNotValid = "messageNotValid" 
        v-on:btnHideDialogNotValid = "btnHideDialogNotValid"
    />


</div>  
</template>

<script>


/* Import Component */

import ProductGridComponent from './Grid/ProductGridComponent.vue'
import ProductToolbarComponent from './Toolbar/ProductToolbarComponent.vue'
import ProductPopupComponent from './Popup/ProductPopupComponent.vue'
import PopupConfirmComponent from './Popup/PopupConfirmComponent.vue'

import ToastSuccessComponent from './Toast/ToastSuccessComponent.vue'
import PopupValidateComponent from './Popup/PopupValidateComponent.vue'



/* Import library */
import axios from 'axios'

/* File Javascript */
import {Resource} from '../assets/js/common/resource'
import {CommonFunction} from '../assets/js/common/commonFunction'
import {Enum} from '../assets/js/common/Enum'
import {ToastJS} from '../assets/js/common/toastJs'

export default {
    name : "product-compoment",
    components : {
        ProductGridComponent,
        ProductToolbarComponent,
        ProductPopupComponent,
        PopupConfirmComponent,
        ToastSuccessComponent,
        PopupValidateComponent
    },
    data(){
        return{
            products : [],
            productCategory : [],
            isShowDialogConfirm : false,
            showDialog : false,
            isCancelSaveConfirm : false,
            isDeleteConfirm : false,
            isAddOrEdit : Enum.FormModel.View,
            /**
             * danh sách các trường chưa valid bắt buộc nhập khi lưu dữ liệu
             */
            ListFieldNotValidRequired : [],
            isShowToastSuccess : false,

             /**
             * Dữ liệu này dùng để load lên form chi tiết
             */
            productEdit : Object.assign({}),

            isShowLoader : false,

            listProductIdToDelete : [],
            isShowDialogValidate : false,
            messageNotValid :"",

            totalPage : 1,
            totalRecord : 0,
            currentPage : 1,
        }
    },

    methods : {


        /**
         * Sự kiện kích hoạt khi chuyển sang trang khác
         * createdBy : NXHoang 
        */
        btnPaging : function(currentPage)
        {
            var self = this;
            self.currentPage = currentPage;
            this.isShowLoader = true;
            axios.get(Resource.API.Host + Resource.API.Product + Resource.API.searchProduct(Resource.SearchPaging.textSearch, Resource.SearchPaging.PageSize ,  currentPage))
            .then(res => {
                self.products = res.data.data;
                self.totalPage = res.data.totalPage;
                self.totalRecord = res.data.totalRecord;
                this.isShowLoader = false;
            })
            .catch((error) => {
                console.log(error)
                this.isShowLoader = false;
            })
        },

        /**
         * Xử lý khi nhấn button Hủy trên dialog thông báo not valid các trường bắt buộc nhập
         * CreatedBy : NXHoang (22/11/2021)
         */
        btnHideDialogNotValid : function()
        {
            try {
                // this.ListFieldNotValidRequired = [];
                this.messageNotValid = "";
                this.isShowDialogValidate = false;
                
            } catch (error) {
                console.log(error)
            }
        },


        /**
         * Method dùng để xóa sản phẩm khi người dùng xác nhận xóa
         * CreatedBy : NXHoang 
        */
        btnConfirmDelete : function()
        {
            try {
                let me = this;
                let listId = '';
                this.listProductIdToDelete.forEach(item => {
                    listId += item + ',';
                });
                listId = listId.slice(0,listId.length - 1);

                
                //gọi API xóa 1 bản ghi của sản phẩm
                
                axios.delete(Resource.API.Host + Resource.API.Product + `/deleteMulti?listId=${listId}`)
                    .then(() => {
                        me.isShowDialogConfirm = false;
                        //Ẩn bỏ các button của dialog confirm
                        me.isCancelSaveConfirm = false;
                        me.isDeleteConfirm = false;
                        me.showToastSuccess(ToastJS.deleteMessageSuccess);
                        this.listProductIdToDelete = [];
                        me.getData();
                    })
                    .catch(() => {
                        me.isShowDialogConfirm = false;
                        //Ẩn bỏ các button của dialog confirm
                        me.isCancelSaveConfirm = false;
                        me.isDeleteConfirm = false;
                    })
            } catch (error) {
                console.log(error)
            }
        },

        insertProductIdToListId : function(listIdSelectedRecord)
        {
            console.log(listIdSelectedRecord);
            this.listProductIdToDelete = listIdSelectedRecord;
        },

        /**
         * Sự kiện dùng để xóa các bản ghi được chọn 
         * CreatedBy : NXHoang (19/11/2021)
        */
        btnDeleteRecord : function()
        {
            try {
                if(this.listProductIdToDelete.length == 0)
                {
                    this.showDialogNotValid(ToastJS.deleteMessageWarning)
                    // this.showToastWarning(ToastJS.deleteMessageWarning);
                }
                else{

                    this.isShowDialogConfirm = true;
                    this.isDeleteConfirm = true;
                    this.messageConfirm = Resource.VN.MessageDialogConfirm.deleteMessage;
                    
                }
            } catch (error) {
                console.log(error)
            }
        },

        /**
         * Method show dialog not valid
        */
        showDialogNotValid : function(message)
        {
            this.messageNotValid = '<span class = "text-notvalid-dialog">' +  message  + '</span>';
            this.isShowDialogValidate = true;
        },

        passProductEdit : function(productEdit)
        {   
            this.productEdit = Object.assign({},productEdit);
        },

        // /**
        //  * Method show popup thực hiện việc sửa sản phẩm
        //  * CreatedBy : NXHoang
        // */
        // showDialogProduct : function()
        // {
        //     this.showDialog = true;
        // },
        /**
         * Method để check xem đang thêm hay đang sửa
         * CreatedBy : NXHoang
        */
        passIsAddOrEdit : function(value)
        {
            this.isAddOrEdit = value;
        },

        /**
         * Method dùng để show toast thông báo Thêm/Sửa thành công nhân viên
         * CreatedBy : NXHoang
         */
        showToastSuccess : function(message){
            try {
                this.messageSuccess = message;
                this.isShowToastSuccess = true;
                setTimeout(() => {
                    this.isShowToastSuccess = false
                } , 3000)
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Method Load dữ liệu grid
         * CreatedBy : NXHoang 31/07/2022
        */
        updateProduct : function()
        {
            this.getData();
        },  

        /**
         * Method ẩn dialog nhập liệu
         * CreatedBy : NXHoang 31/07/2022
        */
        hidedDialogProduct : function()
        {
            this.showDialog = false;
        },


        /**
         * Method xác nhận việc hủy đóng popup thêm/sửa sản phẩm
         * CreatedBy : NXHoang 
        */
        btnNotHideDialogConfirm : function()
        {
            try {
                this.isShowDialogConfirm = false;
                this.isCancelSaveConfirm = false;
                this.isDeleteConfirm = false;
            } catch (error) {
                console.log(error);
            }
        },


        /**
         * Method dùng để đóng popup thêm/sửa sản phẩm
         * CreatedBy : NXHoang
        */
        btnHideDialogConfirm : function(){
            try {
                this.isShowDialogConfirm = false;
                this.showDialog = false;
                //Ẩn bỏ các button của dialog confirm
                this.isCancelSaveConfirm = false;
                this.isDeleteConfirm = false;
            } catch (error) {
                console.log(error);
            }
        },

        /*      
        * method hiển thị dialog confirm cho người dùng về việc đóng popup thêm/sửa sản phẩm
        * CreatedBy : NXHoang
        */
        confirmHidedDialog : function(message , isCancelSaveConfirm){
            try {
                this.isShowDialogConfirm = true;
                this.messageConfirm = message;
                this.isCancelSaveConfirm = isCancelSaveConfirm;
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Method thực hiện việc selected các item của combobox
         * CreatedBy : NXHoang 
         */
        itemComboboxClick(data){
      
            CommonFunction.selectedItemCombobox(data);
        },

        /**
         * Lấy danh sách sản phẩm
         * CreatedBy : NXHoang (30/07/2022)
        */
        getData(){
            var me = this;
            this.isShowLoader = true;
            // axios.get(Resource.API.Host + Resource.API.GetProductApi)
            axios.get(Resource.API.Host + Resource.API.Product + Resource.API.searchProduct(Resource.SearchPaging.textSearch, Resource.SearchPaging.PageSize ,  me.currentPage))
            .then(res => {
                this.isShowLoader = false;
                me.products = res.data.data;
                me.totalPage = res.data.totalPage;
                me.totalRecord = res.data.totalRecord;
                this.isShowLoader = false;
            })
            .catch(error => {
                this.isShowLoader = false;
                console.log(error)
            })
        },

        /**
         * Lấy danh sách danh mục sản phẩm
         * CreatedBy : NXHoang (30/07/2022)
        */
        getProductCategories(){
            var me = this;
            axios.get(Resource.API.Host + Resource.API.GetProductCategory)
            .then(res => {
                me.productCategory = res.data.result;
            })
            .catch(error => {
                console.log(error)
            })
        },


        /**
         * Method thực hiện show dialog chi tiết sản phẩm
         * createdBy : NXHoang 
        */
        showDialogProduct(){
             
            this.showDialog = true;
        },

        /**
         * Method dùng để đánh dấu là thêm sản phẩm
         * CreatedBy : NXHoang 
         */
        setIsProduct()
        {
            this.isAddOrEdit = Enum.FormModel.Add;
        }


    },

    created() {
        this.getData();
        this.getProductCategories();
    },
}
</script>

<style>

</style>