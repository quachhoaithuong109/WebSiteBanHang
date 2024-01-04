<template>
    <div>
        <ProductCategoryToolbarComponent  
            v-on:showDialogProduct = "showDialogProduct" 
            v-on:setIsProductCategory ="setIsProductCategory" 
            v-on:showDialogProductCategory = "showDialogProductCategory"
            v-on:btnDeleteRecord = "btnDeleteRecord"
        />

        <ProductCategoryGridComponent 
            v-bind:productCategories="productCategories" 
            v-on:passIsAddOrEdit = "passIsAddOrEdit"
            v-on:passProductCategoryEdit = "passProductCategoryEdit"
            v-on:showDialogProductCategory = "showDialogProductCategory"
            v-on:insertProductCategoryIdToListId = "insertProductCategoryIdToListId"
        />

        <ProductCategoryPopupComponent 
            v-if="showDialog" 
            v-on:confirmHidedDialog = "confirmHidedDialog" 
            v-bind:listFieldNotValidRequired = "ListFieldNotValidRequired"
            v-bind:isAddOrEdit = "isAddOrEdit"
            v-on:updateProductCategory = "updateProductCategory"
            v-on:showToastSuccess = "showToastSuccess"
            v-on:hidedDialogProductCategory = "hidedDialogProductCategory"
            v-bind:productCategoryEdit = "productCategoryEdit"
        />


        <PopupConfirmComponent 
            v-show = "isShowDialogConfirm"
            v-bind:messageConfirm = "messageConfirm"
            v-bind:isCancelSaveConfirm = "isCancelSaveConfirm"
            v-on:btnHideDialogConfirm = "btnHideDialogConfirm"
            v-bind:isDeleteConfirm = "isDeleteConfirm"
            v-on:btnNotHideDialogConfirm = "btnNotHideDialogConfirm"
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


import axios from 'axios'
import PopupValidateComponent from './Popup/PopupValidateComponent.vue'

/* JS */

import {Resource} from '../../src/assets/js/common/resource'
import {Enum} from '../../src/assets/js/common/Enum'
import {ToastJS} from '../../src/assets/js/common/toastJs'

/* import component */
import ProductCategoryToolbarComponent from '../components/Toolbar/ProductCategoryToolbarComponent.vue'
import ProductCategoryGridComponent from '../components/Grid/ProductCategoryGridComponent.vue'

import ProductCategoryPopupComponent from '../components/Popup/ProductCategoryPopupComponent.vue'

import ToastSuccessComponent from '../components/Toast/ToastSuccessComponent.vue'
import PopupConfirmComponent from '../components/Popup/PopupConfirmComponent.vue'

export default {
    name : "product-category-component",
    components : {
       ProductCategoryToolbarComponent,
       ProductCategoryGridComponent,
       ProductCategoryPopupComponent,
       ToastSuccessComponent,
       PopupConfirmComponent,
       PopupValidateComponent
    },
    data(){
        return{
            productCategories  : [],
            isShowLoader : false,
            currentPage : 1,
            showDialog : false,
            isAddOrEdit : Enum.FormModel.View,
            isShowDialogConfirm : false,

            /**
             * danh sách các trường chưa valid bắt buộc nhập khi lưu dữ liệu
             */
            ListFieldNotValidRequired : [],
            isShowToastSuccess : false,
            messageSuccess : "",

            /**
             * Dữ liệu này dùng để load lên form chi tiết
             */
            productCategoryEdit : Object.assign({}),

            isCancelSaveConfirm : false,
            isDeleteConfirm : false,
            listProductCategoryIdToDelete : [],
            isShowDialogValidate : false,
            messageNotValid :"",
        }
    },

    methods : {

        /**
         * Method dùng để xóa sản phẩm khi người dùng xác nhận xóa
         * CreatedBy : NXHoang 
        */
        btnConfirmDelete : function()
        {
            try {
                let me = this;
                let listId = '';
                this.listProductCategoryIdToDelete.forEach(item => {
                    listId += item + ',';
                });
                listId = listId.slice(0,listId.length - 1);

                
                //gọi API xóa 1 bản ghi của sản phẩm
                
                axios.delete(Resource.API.Host + Resource.API.ProductCategory + `/deleteMulti?listId=${listId}`)
                    .then(() => {
                        me.isShowDialogConfirm = false;
                        //Ẩn bỏ các button của dialog confirm
                        me.isCancelSaveConfirm = false;
                        me.isDeleteConfirm = false;
                        me.showToastSuccess(ToastJS.deleteMessageSuccess);
                        this.listProductCategoryIdToDelete = [];
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
         * Sự kiện dùng để xóa các bản ghi được chọn 
         * CreatedBy : NXHoang (19/11/2021)
        */
        btnDeleteRecord : function()
        {
            try {
                if(this.listProductCategoryIdToDelete.length == 0)
                {
                    this.showDialogNotValid(ToastJS.deleteMessageWarning)
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

        insertProductCategoryIdToListId : function(listIdSelectedRecord)
        {
            this.listProductCategoryIdToDelete = listIdSelectedRecord;
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


        passProductCategoryEdit : function(productCategoryEdit)
        {   
            this.productCategoryEdit = Object.assign({},productCategoryEdit);
        },

        /**
         * Method để check xem đang thêm hay đang sửa
         * CreatedBy : NXHoang
        */
        passIsAddOrEdit : function(value)
        {
            this.isAddOrEdit = value;
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
         * Lấy danh sách danh mục sản phẩm
         * CreatedBy : NXHoang
        */
        getData(){
            var me = this;
            this.isShowLoader = true;
            // axios.get(Resource.API.Host + Resource.API.GetProductAp)i
            axios.get(Resource.API.Host + Resource.API.ProductCategory + Resource.API.searchProductCategory(Resource.SearchPaging.textSearch, Resource.SearchPaging.PageSize ,  me.currentPage))
            .then(res => {
                this.isShowLoader = false;
                me.productCategories = res.data.data;
                // me.totalPage = res.data.totalPage;
                // me.totalRecord = res.data.totalRecord;
            })
            .catch(error => {
                // this.isShowLoader = false;
                console.log(error)
            })
        },

        /**
         * Method thực hiện show dialog chi tiết sản phẩm
         * createdBy : NXHoang 
        */
        showDialogProductCategory(){
            this.showDialog = true;
        },

        /**
         * Method dùng để đánh dấu là thêm danh mục sản phẩm
         * CreatedBy : NXHoang 
         */
        setIsProductCategory()
        {
            this.isAddOrEdit = Enum.FormModel.Add;
        },

        /**
         * Method ẩn dialog nhập liệu
         * CreatedBy : NXHoang 31/07/2022
        */
        hidedDialogProducCategort : function()
        {
            this.showDialog = false;
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
         * Method ẩn dialog nhập liệu
         * CreatedBy : NXHoang 31/07/2022
        */
        hidedDialogProductCategory : function()
        {
            this.showDialog = false;
        },


        /**
         * Method Load dữ liệu grid
         * CreatedBy : NXHoang 31/07/2022
        */
        updateProductCategory : function()
        {
            this.getData();
        },  

    },

    created() {
        this.getData();
    },
}
</script>

<style>

</style>