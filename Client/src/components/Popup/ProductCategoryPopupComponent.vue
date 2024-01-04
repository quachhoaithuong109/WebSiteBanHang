<template>
   <div class="m-popup toggle-popup">
        <div class="wrap-popup"></div>
        <div class="popup-info-assets">
            <div class="header-popup">
                Thông tin danh mục sản phẩm
                <button class="close-popup" id="close-popup" v-on:click="hidedDialogProductCategory"></button>
            </div>
            <div class="content-popup" ref="contentPopup">
                <div class = "form-product form-product-first">
                    <div class="input-form first-input-form">
                        <label>Tên danh mục sản phẩm<span style="color: red;">*</span></label><br />
                        <input 
                            type="text" 
                            class="input-popup-left first-field-popup input-text" 
                            nameToValidate = "Tên danh mục sản phẩm"
                            fieldName = "ProductCategoryName"
                            v-model = "productCategory.ProductCategoryName"
                            required
                            @blur = "validateFieldRequired($event)"
                        />
                        <span class="tooltiptext"></span>
                    </div>
                    <div class="input-form first-input-form">
                        <label>Alias <span style="color: red;">*</span></label><br />
                        <input 
                            type="text" 
                            class="input-popup-left first-field-popup input-text" 
                            nameToValidate = "Alias"
                            fieldName = "Alias"
                            v-model = "productCategory.Alias"
                            required
                            @blur = "validateFieldRequired($event)"
                        />
                        <span class="tooltiptext"></span>
                    </div>
                </div>

                <div class="form-product">
                     <div class="input-form text-full-form">
                        <label>Mô tả </label><br />
                        
                        <textarea 
                            class="textarea-popup-right input-text" 
                            fieldName = "Description"
                            v-model = "productCategory.Description"
                        ></textarea>
                        <span class="tooltiptext"></span>
                    </div>
                </div>

            </div>
            <div class="footer-popup">
                <div class="wrap-button-footer">
                    <button type="button" class="m-btn-cancel" id="btn-close-popup" v-on:click = "hidedDialogProductCategory">
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


/* JS */
import {Enum} from '../../assets/js/common/Enum' 
import {CommonFunction} from '../../assets/js/common/commonFunction' 
import {Resource} from '../../assets/js/common/resource' 
import {Common} from '../../assets/js/common/common' 
import {ToastJS} from '../../assets/js/common/toastJs'

export default {

    data(){
        return{
            productCategory : {
                ProductCategoryId : "",
                ProductCategoryName : "",
                Alias : "",
                Description : "",
            },
        }
    },

    props:{
        listFieldNotValidRequired : {
            type : Array
        },
        isAddOrEdit : {
            type : Number
        },

        productCategoryEdit : {
            type:Object
        }
    },


    created()
    {
        try {            
            if(this.isAddOrEdit == Enum.FormModel.Edit)
            {
                this.productCategory.ProductCategoryId = this.productCategoryEdit.productCategoryId
                this.productCategory.ProductCategoryName = this.productCategoryEdit.productCategoryName
                this.productCategory.Alias = this.productCategoryEdit.alias
                this.productCategory.Description = this.productCategoryEdit.description
            }
        } catch (error) {
            console.log(error);
        }
    },

    methods : {
        

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
                var value = this.productCategory[fieldName];
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
        hidedDialogProductCategory(){
            this.$emit('confirmHidedDialog', Resource[Common.LanguageCode].MessageDialogConfirm.ConfirmHidePopupProduct, true);
        },


        /**
         * Method thực hiện việc Thêm/Sửa sản phẩm
         * CreatedBy : NXHoang 
        */
        btnSaveClick(){
            try {
                // var me = this;
                this.checkValidate = true;
                var dialogContent =  this.$refs.contentPopup;
                var inputRequires = dialogContent.querySelectorAll('input[required]');
                for(let inputRequired of inputRequires)
                {
                    inputRequired.focus();
                    inputRequired.blur();
                }
            
                var newProductCategory = CommonFunction.createObjectProductCategory(this.productCategory); 
                
                if(this.checkValidate)
                {
                    if(this.isAddOrEdit == Enum.FormModel.Add || this.isAddOrEdit == Enum.FormModel.Replication)
                    {
                        axios.post(Resource.API.Host + Resource.API.ProductCategory +  Resource.API.AddNewProductCategory, newProductCategory)
                        .then(() => {
                            this.$emit('hidedDialogProductCategory');
                            this.$emit('updateProductCategory');
                            this.$emit('showToastSuccess' , ToastJS.successMessage);
                        })
                        .catch(error => {
                            if(error.response.status == 400){
                                console.log(error.response)
                            }
                            else{
                                console.log(error.response)
                            }
                        })
                    }else{

                        axios.put(Resource.API.Host + Resource.API.ProductCategory +  Resource.API.UpdateProductCategory , newProductCategory)
                        .then(() => {
                            this.$emit('hidedDialogProductCategory');
                            this.$emit('updateProductCategory');
                            this.$emit('showToastSuccess' , ToastJS.successMessage);
                        })
                        .catch(error => {
                            if(error.response.status == 400){
                                console.log(error)
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

    }


}
</script>

<style>

</style>