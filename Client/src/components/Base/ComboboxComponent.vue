<template>
    <div class="m-combobox m-combobox-popup m-combobox-loadData" v-bind:class="{ 'comboboxRequired': required }" v-bind:nameId = "idItem" v-bind:fieldNameItem = "nameItem" v-bind:nameToValidate = "nameToValidate">
        <input type = "text" class="m-combobox-input input-text" @focus = "onFocusToggleItemCombobox" @blur = "onHideItemCombobox"  />
        <button class="m-combobox-button" v-on:click = "btnButtonCombobox($event)" ref="buttonCombobox">
            <i class="fa fa-angle-down" aria-hidden="true"></i>
        </button>
        <div class="m-combobox-select m-hidden-dropdown" ref = "listTtemCombobox">
           <div class="m-combobox-item" v-bind:value = "item[idItem]" v-on:mousedown = "itemComboboxClick(item[idItem] , item[nameItem] , $event)" v-for = "item in dataCombobox" :key="item[idItem]">
                {{item[nameItem]}}
            </div>
        </div>
    </div>
</template> 


<script>

/* import file js */

import { CommonFunction } from '@/assets/js/common/commonFunction';

import {Enum} from '@/assets/js/common/Enum'
import {Resource} from '@/assets/js/common/resource'
import {Common} from '@/assets/js/common/common'

export default {
    data(){
        return{
            isEventCombobox : Enum.ComboboxModel.Default,
            selected : {},
        }
    },

    props:{
        dataCombobox : {
            type:Array
        },
        idItem : {
            type : String
        },
        nameItem : {
            type : String
        },
        required : {
            type : Boolean
        },
        nameToValidate : {
            type : String
        },
        valueIdItem : {
            type : String
        },
        isAddOrEdit : {
            type : Number
        } 
    },

    created(){
        if(this.isAddOrEdit == Enum.FormModel.Edit || this.isAddOrEdit == Enum.FormModel.Replication)
        {
            var dataItemSelectedCombobox = this.dataCombobox.find(val => val[this.idItem] == this.valueIdItem);
            this.selected.id = dataItemSelectedCombobox[this.idItem];
            this.selected.code = dataItemSelectedCombobox[this.codeItem];
            this.selected.name = dataItemSelectedCombobox[this.nameItem];
        }
    },


    methods :{

        

        /**
         * Method xử lý việc select giá trị của combobox
         * CreatedBy : NXHoang 
        */
        itemComboboxClick : function(id ,name , event){
            this.isEventCombobox = Enum.ComboboxModel.MouseDown;
            this.selected.id = id;
            // this.selected.code = code;
            this.selected.name = name;
            this.$emit('itemComboboxClick' , id,name ,event);
        },

    
        /**
         * Method xử lý việc show/Ẩn combobox
         * CreatedBy : NXHoang 
        */
        btnButtonCombobox : function(event)
        {
            console.log(event);
            // this.$emit('btnButtonCombobox' , event);
        },

        /**
         * Thực hiện việc Autocomplete khi focus vào combobox
         * CreatedBy : NXHoang
        */
        onFocusToggleItemCombobox : function()
        {
            // this.filteredOptions = this.dataCombobox;
            var cbSelected = this.$refs.listTtemCombobox;
            var buttonCombobox = this.$refs.buttonCombobox;
            CommonFunction.onFocusToggleItemCombobox(cbSelected , buttonCombobox);
        },

        /**
         * Method xử lý sự kiện khi blur khỏi combobox
         * CreatedBy : NXHoang 
        */
        onHideItemCombobox : function()
        {
            const cbSelected = this.$refs.listTtemCombobox;
            if(this.isEventCombobox == Enum.ComboboxModel.MouseDown)
            {
                this.isEventCombobox = Enum.ComboboxModel.Default;
            }
            else{
                
                if(!this.selected.id)
                {
                    this.selected = {};
                    var cbRequired = document.querySelector(`[fieldNameItem="${this.nameItem}"]`);
                    if(cbRequired)
                    {
                        cbRequired.classList.add('border-red');
                        var toolTip = cbRequired.parentElement.querySelector(".tooltiptext");
                        toolTip.classList.add("showTooltip")
                        toolTip.innerText = Resource[Common.LanguageCode].Validate.Required(this.nameToValidate);
                        // cbRequired.setAttribute('title' , Resource[Common.LanguageCode].Validate.Required(this.nameToValidate));
                        cbRequired.setAttribute('validate' , false)
                        this.checkValidate = false;
                    } 
                    //Đổi lại icon tại nút button của combobox
                    var buttonCb = cbRequired.getElementsByTagName("button");
                    buttonCb[0].innerHTML = Resource.Icon.FaChevronDown.toString();
                    
                }else{
                    var itemSelected = cbSelected.querySelectorAll(`div[value="${this.selected.id}"]`)[0];
                    this.itemComboboxClick(this.selected.id ,this.selected.name ,itemSelected);
                    this.isEventCombobox = Enum.ComboboxModel.Default;
                }
            }
            if(cbSelected.classList.contains("m-hidden-dropdown") == false)
            {
                cbSelected.classList.add("m-hidden-dropdown");
            }
        },

    },

    mounted(){
        console.log(this.dataCombobox);
    }

}
</script>

<style>

</style>