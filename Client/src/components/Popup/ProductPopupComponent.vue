<template>
    <div class="m-popup toggle-popup">
        <div class="wrap-popup"></div>
        <div class="popup-info-assets">
            <div class="header-popup">
                Thông tin sản phẩm  
                <button class="close-popup" id="close-popup" v-on:click="hidedDialogProduct"></button>
            </div>
            <div class="content-popup" ref="contentPopup">
                <div class = "form-product form-product-first">
                    <div class="input-form first-input-form">
                        <label>Tên sản phẩm<span style="color: red;">*</span></label><br />
                        <input 
                            type="text" class="input-popup-left first-field-popup input-text" 
                            fieldName = "ProductName"  
                            title = ""
                            v-model = "product.ProductName"
                            required
                            @blur = "validateFieldRequired($event)"
                            nameToValidate = "Tên sản phẩm"
                        />
                        <span class="tooltiptext"></span>
                    </div>
                    <div class="input-form first-input-form">
                        <label>Loại sản phẩm <span style="color: red;">*</span></label><br />
                        <!-- <input 
                            type="text" class="input-popup-right input-text"
                        /> -->
                        <ComboboxComponent 
                            v-bind:dataCombobox ="productCategory" 
                            v-bind:idItem = "'productCategoryId'" 
                            v-bind:nameItem = "'productCategoryName'"
                            v-on:itemComboboxClick = "itemComboboxClick"
                            v-bind:nameToValidate = "'Loại sản phẩm'"
                            v-bind:required = true
                            v-bind:valueIdItem = "product.CategoryID"
                            v-bind:isAddOrEdit = "isAddOrEdit"
                        />

                        <span class="tooltiptext fixedAssetName-tooltiptext"></span>
                    </div>
                </div>
                
                <div class="form-product">
                     <div class="input-form first-input-form">
                        <label>Giá sản phẩm<span style="color: red;">*</span></label><br />
                        
                        <input 
                            type="text" 
                            class="input-popup-right input-text"  
                            fieldName = "Price" 
                            v-model = "product.Price"
                            required
                            @blur = "validateFieldRequired($event)"
                            @keydown="restricCharacter($event)" 
                            nameToValidate = "Giá sản phẩm"
                            ref="Price"
                            
                        />
                        <span class="tooltiptext"></span>
                    </div>
                    <div class="input-form first-input-form">
                        <label>Giá khuyến mại </label><br />
                        <input 
                            type="text" class="input-popup-right input-text" 
                            fieldName = "PromotionPrice" 
                            v-model = "product.PromotionPrice"
                            @keydown="restricCharacter($event)" 
                            ref="PromotionPrice"
                        />
                        <span class="tooltiptext fixedAssetName-tooltiptext"></span>
                    </div>
                </div>

                <div class="form-product">
                     <div class="input-form first-input-form">
                        <label>Số lượng<span style="color: red;">*</span></label><br />
                        
                        <input 
                            type="text" class="input-popup-right input-text" 
                            fieldName = "Quantity" 
                            v-model = "product.Quantity"
                            required
                            @blur = "validateFieldRequired($event)"
                            nameToValidate = "Số lượng"
                            @keydown="restricCharacter($event)"
                        />
                        <span class="tooltiptext"></span>
                    </div>
                    <div class="input-form first-input-form">
                        <label>Bảo hành </label><br />
                        <input 
                            type="text" class="input-popup-right input-text" 
                            fieldName = "Warranty"
                            v-model = "product.Warranty"
                            @keydown="restricCharacter($event)"
                        />
                        <span class="tooltiptext fixedAssetName-tooltiptext"></span>
                    </div>
                </div>
                
                <div class="form-product">
                     <div class="input-form first-input-form">
                        <label>Alias </label><br />
                        
                        <input 
                            type="text" class="input-popup-right input-text" 
                            fieldName = "Alias"
                            v-model = "product.Alias"
                        />
                        <span class="tooltiptext"></span>
                    </div>
                    <div class="input-form first-input-form">
                        <!-- <label>Hình ảnh <span style="color: red;">*</span></label><br /> -->
                        <input style="display: none" type="file" ref="fileInput" @change="onFilePicked" />

                        <!-- <input 
                            type="text" class="input-popup-right input-text"
                        /> -->
                        <div class="wrap-uploadImage">
                           
                            <button type="button" class="btn btn-primary btn-upload-img" v-on:click="onPickFile">
                                <i class="fa fa-upload" aria-hidden="true"></i>
                                <span>Chọn hình ảnh</span>
                            </button>    
                             <div class="img-upload">
                                <img class="image-upload" :src = "srcImage" />
                            </div>
                        </div>
                        <span class="tooltiptext fixedAssetName-tooltiptext"></span>
                    </div>
                </div>

                <div class="form-product">
                     <div class="input-form text-full-form">
                        <label>Mô tả </label><br />
                        
                        <textarea 
                            class="textarea-popup-right input-text" 
                            fieldName = "Content"
                            v-model = "product.Content"
                        ></textarea>
                        <span class="tooltiptext"></span>
                    </div>
                </div>

            </div>
            <div class="footer-popup">
                <div class="wrap-button-footer">
                    <button type="button" class="m-btn-cancel" id="btn-close-popup" v-on:click = "hidedDialogProduct">
                        Hủy
                    </button>
                    <button type="button" class="m-btn m-btn-save" id="btnSave" v-on:click = "btnSaveClick">
                        Lưu
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>


<script>

import axios from 'axios'

/* Import file js */

import {Enum} from '../../assets/js/common/Enum' 
import {CommonFunction} from '../../assets/js/common/commonFunction' 
import {Resource} from '../../assets/js/common/resource' 
import {Common} from '../../assets/js/common/common' 
import {ToastJS} from '../../assets/js/common/toastJs'

/* Import Component */
import ComboboxComponent from '../Base/ComboboxComponent.vue'
// import InputTypeNumberComponent from '../Base/InputTypeNumberComponent.vue'


export default {
    data(){
        return{
            checkValidate : false,
            product : {
                //thêm mới không cần gán Id
                ProductName : "",
                CategoryID : "",
                Price : 0,
                PromotionPrice : 0,
                Quantity : 0,
                Warranty : 0,
                Alias : 0,
                Image : "",
                Content : ""    
            },
            fileUpload : null,
            srcImage : ""
        }
    },

    props :{
        productCategory : {
            type : Array
        },
        isAddOrEdit : {
            type : Number
        },
        listFieldNotValidRequired : {
            type : Array
        },
        productEdit : {
            type:Object
        }
    },

    created()
    {
        try {            
            if(this.isAddOrEdit == Enum.FormModel.Edit)
            {
                this.product.ProductId = this.productEdit.productId
                this.product.ProductName = this.productEdit.productName
                this.product.CategoryID = this.productEdit.categoryID
                this.product.Price = CommonFunction.formatMoney(this.productEdit.price)
                this.product.PromotionPrice = CommonFunction.formatMoney(this.productEdit.promotionPrice)
                this.product.Quantity = this.productEdit.quantity
                this.product.Warranty = this.productEdit.warranty
                this.product.Alias = this.productEdit.alias
                this.product.Image = this.productEdit.image
                this.product.Content = this.productEdit.content
                
                let src = "";
                switch(this.productEdit.typeProduct) {
                    case Resource.VN.TypeProduct.Phone:
                        src = Resource.VN.SrcImage.Phone + this.productEdit.image;
                        break;
                    case Resource.VN.TypeProduct.Laptop:
                        src = Resource.VN.SrcImage.Laptop + this.productEdit.image;
                        break;
                    case Resource.VN.TypeProduct.Tablet:
                        src = Resource.VN.SrcImage.Tablet + this.productEdit.image;
                        break;
                    case Resource.VN.TypeProduct.Tivi:
                        src = Resource.VN.SrcImage.Tivi + this.productEdit.image;
                        break;
                    default:
                        src = "";
                        break;
                }

                this.srcImage = src;
            }
        } catch (error) {
            console.log(error);
        }

        console.log(this.product);
    },

    mounted(){
        if(this.isAddOrEdit == Enum.FormModel.Edit || this.isAddOrEdit == Enum.FormModel.Replication){
            var cbPopups = this.$refs.contentPopup.getElementsByClassName('m-combobox');
            for(let cbPopup of cbPopups)
            {
                var fieldName = cbPopup.getAttribute('nameId');
                console.log(fieldName);
                var cbItems = cbPopup.getElementsByClassName('m-combobox-item');

                for(let cbItem of cbItems){
                    var value = cbItem.getAttribute('value');
                    if(this.product.CategoryID == value)
                    {
                        cbPopup.getElementsByClassName('m-combobox-input')[0].value = cbItem.innerText.toString();
                        cbItem.classList.add("m-item-selected")
                        cbItem.innerHTML = Resource.Icon.FaCheck.toString() + cbItem.innerText.toString();
                        break;
                    }
                }
            } 
        }
    },

    methods : {
        
        /**
         * Xử kiện xử lý việc nhập khẩu dữ liệu từ file execl
         * CreatedBy : NXHoang (23/11/2021)
        */
        onFilePicked : function(event)
        {
            try {
                let files = event.target.files;
                this.fileUpload = files[0];
                // console.log(this.fileUpload);
                this.srcImage =  URL.createObjectURL(event.target.files.item(0));
                
            } catch (error) {
                console.log(error);
            }
        },


        /**
         * Sự kiện được sử dụng cho việc upload file 
         * CreatedBy : NXHoang 
        */
        onPickFile : function()
        {
            this.$refs.fileInput.click();
        },



        /**
         * Method hạn chế nhập ký tự character vào các ô nhập vào là chữ số
         * CreatedBy : NXHoang (16/11/2021)
        */
        restricCharacter : function(e){
            if ((/^\d*$/.test(e.key) == false && e.keyCode != 8 && e.keyCode != 9) || e.key < 0) {
                e.preventDefault();
            }
        },


        /**
         * Method thực hiện validate các trường bắt buộc nhập
         * CreatedBy : NXHoang
        */
        validateFieldRequired : function(event){
            try {

                var self = this;
                var input = event.target;
                var fieldName = input.getAttribute('fieldname');
                var nameToValidate = input.getAttribute('nameToValidate');
                var value = this.product[fieldName];
                var tootlTip = input.parentElement.querySelector('.tooltiptext');
                if(input.classList.contains("input-typenumber-popup"))
                {
                    tootlTip = input.parentElement.parentElement.querySelector('.tooltiptext');
                }
                //Bắt buộc nhập
                if(!value){
                    self.listFieldNotValidRequired.push(nameToValidate);
                    input.classList.add('border-red');
                    tootlTip.classList.add("showTooltip")
                    tootlTip.innerText = Resource[Common.LanguageCode].Validate.Required(nameToValidate);
                    input.setAttribute('validate' , false)
                    this.checkValidate = false;
                }
                else{
                    input.classList.remove('border-red');
                    tootlTip.classList.remove("showTooltip")
                    input.removeAttribute('validate')
                }
            } catch (error) {
                console.log(error)
            }
        },

        /**
         * Method thực hiện close Popup form chi tiết sản phẩm
         * CreatedBy : NXHoang 
        */
        hidedDialogProduct(){
            this.$emit('confirmHidedDialog', Resource[Common.LanguageCode].MessageDialogConfirm.ConfirmHidePopupProduct, true);
        },

        /**
         * Method xử lý khi selected 1 giá trị của combobox
         * CreatedBy : NXHoang (16/11/2021)
        */
        itemComboboxClick(id ,name , event){
            
            try {
                var data = {
                    name : name,
                    id : id,
                    event : event
                }
                var cbItem;
                if(event.target)
                {
                    cbItem = event.target;
                }else{
                    cbItem = event;
                }
                
                var combobox = cbItem.parentElement.parentElement;
                // var fieldName = cbItem.parentElement.parentElement.getAttribute('fieldName')
                var fieldName = combobox.getAttribute('nameId')
               
                this.product[fieldName] = id;
                this.product.CategoryID = id;
                if(this.product[fieldName])
                {
                    combobox.classList.remove('border-red');
                    var toolTip =  combobox.parentElement.querySelector(".tooltiptext");
                    toolTip.classList.remove("showTooltip");
                    combobox.removeAttribute('validate')
                }
                this.$emit('itemComboboxClick' , data);
            } catch (error) {
                console.log(error)
            }
        },

        /**
         * Method thực hiện việc Thêm/Sửa sản phẩm
         * CreatedBy : NXHoang 
        */
        btnSaveClick(){
            try {
                
                var me = this;
                this.checkValidate = true;
                var dialogContent =  this.$refs.contentPopup;
                var inputRequires = dialogContent.querySelectorAll('input[required]');
                for(let inputRequired of inputRequires)
                {
                    inputRequired.focus();
                    inputRequired.blur();
                }
                me.validateComboboxRequired();
            
                var newProduct = CommonFunction.createObjectToAddOrEdit(this.product); 
                
                if(this.checkValidate)
                {
                    if(this.isAddOrEdit == Enum.FormModel.Add || this.isAddOrEdit == Enum.FormModel.Replication)
                    {
                        let formData = new FormData();
                        formData.append('formFile',this.fileUpload);
                        formData.append('product',JSON.stringify(newProduct));

                        axios.post("https://localhost:44397/api/v1/Product/AddNewProduct" , formData, { headers: {'Content-Type': 'multipart/form-data'}})
                        .then(() => {
                            this.$emit('hidedDialogProduct');
                            this.$emit('updateProduct');
                            this.$emit('showToastSuccess' , ToastJS.successMessage);
                        })
                        .catch(error => {
                            if(error.response.status == 400){
                                // this.$emit('showDialogNotValid' , error.response.data.Data.userMsg)
                            }
                            else{
                                // this.$emit('showDialogNotValid' ,ToastJS.errorMessage)
                                // console.log("There was an error!", error);
                            }
                        })
                    }else{

                        let formData = new FormData();
                        formData.append('formFile',this.fileUpload);
                        formData.append('product',JSON.stringify(newProduct));

                        axios.put("https://localhost:44397/api/v1/Product/UpdateProduct" , formData, { headers: {'Content-Type': 'multipart/form-data'}})
                        .then(() => {
                            this.$emit('hidedDialogProduct');
                            this.$emit('updateProduct');
                            this.$emit('showToastSuccess' , ToastJS.successMessage);
                        })
                        .catch(error => {
                            if(error.response.status == 400){
                                // this.$emit('showDialogNotValid' , error.response.data.Data.userMsg)
                            }
                            else{
                                // this.$emit('showDialogNotValid' ,ToastJS.errorMessage)
                                // console.log("There was an error!", error);
                            }
                        })

                        
                    }
                }else{
                    
                
                    var inputNotValid = dialogContent.querySelectorAll('input[validate="false"]')
                    inputNotValid[0].focus();
                }
            } catch (error) {
                console.log(error)
            }
        },

        /**
         * Method thực hiện validate các combobox bắt buộc chọn
         * CreatedBy : NXHoang
        */
        validateComboboxRequired : function()
        {
            var self = this;
            try {
                var dialogContent =  this.$refs.contentPopup;
                var comboboxRequired = dialogContent.querySelectorAll('.comboboxRequired');
            
                for(let element of comboboxRequired)
                {
                    var nameIdCombobox =  element.getAttribute("nameId");
                    var nameToValidate = element.getAttribute("nameToValidate");
                    var toolTip = element.parentElement.querySelector(".tooltiptext");
                    if(!this.product[nameIdCombobox])
                    {
                        self.listFieldNotValidRequired.push(nameToValidate);
                        element.classList.add('border-red');
                       
                        toolTip.classList.add("showTooltip");
                        toolTip.innerText = Resource[Common.LanguageCode].Validate.Required(nameToValidate);

                        element.firstElementChild.setAttribute('validate' , false);
                        this.checkValidate = false;
                    }else{
                        element.classList.remove('border-red');
                        toolTip.classList.remove("showTooltip");
                        element.firstElementChild.removeAttribute('validate')
                    }
                }
            } catch (error) {
                console.log(error);
            }
        },

    },

    components:{
        ComboboxComponent,
    },

    watch : {
        'product.Price' : function(val){
            try{
                var value = CommonFunction.convertMoneyToNumber(val);
               
                var input = this.$refs.Price;
                var tootlTip = input.parentElement.querySelector('.tooltiptext');
                if(val)
                {
                    input.classList.remove('border-red');
                    tootlTip.classList.remove('showTooltip')
                    input.removeAttribute('validate')
                }else{
                    var nameToValidate = input.getAttribute('nameToValidate');
                    input.classList.add('border-red');
                    tootlTip.classList.add("showTooltip");
                    tootlTip.innerText = Resource[Common.LanguageCode].Validate.Required(nameToValidate);
                    input.setAttribute('validate' , false);
                }

                value = CommonFunction.formatMoney(value);
                this.product.Price = value;
            }catch (error) {
                console.log(error)
            }
        },

        'product.PromotionPrice' : function(val)
        {
            try{
                var value = CommonFunction.convertMoneyToNumber(val);
                var input = this.$refs.PromotionPrice;
                var tootlTip = input.parentElement.querySelector('.tooltiptext');
                if(val)
                {
                    input.classList.remove('border-red');
                    tootlTip.classList.remove('showTooltip')
                    input.removeAttribute('validate')
                }else{
                    var nameToValidate = input.getAttribute('nameToValidate');
                    input.classList.add('border-red');
                    tootlTip.classList.add("showTooltip");
                    tootlTip.innerText = Resource[Common.LanguageCode].Validate.Required(nameToValidate);
                    input.setAttribute('validate' , false);
                }

                value = CommonFunction.formatMoney(value);
                this.product.PromotionPrice = value;
            }catch (error) {
                console.log(error)
            }
        }
    }


}
</script>

<style>

</style>