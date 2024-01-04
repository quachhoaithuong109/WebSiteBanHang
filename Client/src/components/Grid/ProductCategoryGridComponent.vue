<template>
  
    <div class="row grid-product">
        <div class="col-12">
            <div class="grid">
                <div class="content-grid">
                    <table class="table-grid-load">
                        <thead class="thead-table">
                            <tr>
                                <th class="checkbox-table">
                                    <input type="checkbox" class = "grid-checkbox checkbox-header-grid">
                                </th>
                                <th class="stt-table align-center m-wrap-tooltip">
                                    STT
                                </th>
                                <th>Tên danh mục</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            
                            <tr v-for = "(item, index) in productCategories" :key="item.productCategoryId" :ref = "item.productCategoryId" @mouseover = "showFeatureRecord(item.productCategoryId)" @mouseleave = "hideFeatureRecord(item.productCategoryId)">
                                <th class="checkbox-table">
                                    <input type = "hidden" class = "input-hidden" />
                                    <input type="checkbox" class = "grid-checkbox" v-on:click = "btnSeclectedDelete(item.productCategoryId,$event)">
                                </th>
                                <td class="stt-table align-center">
                                    {{index + 1}}
                                </td>
                                <td>{{item.productCategoryName}}</td>
                                
                                <td class = "wrap-icon-feature ">
                                    <div class = "feature hide-feature"><!--hide-feature-->
                                        <div class = "edit-record wrap-icongrid-tooltip" v-on:click = "btnShowDialogToEdit(item.productCategoryId)">
                                            <span class="grid-tooltiptext showTooltip-filterbar">Sửa</span>
                                        </div>
                                        <div class = "replication-record wrap-icongrid-tooltip"> 
                                            <span class="grid-tooltiptext showTooltip-filterbar tooltiptext-replication">Nhân bản</span>
                                        </div>
                                    </div>
                                </td>
                            </tr>

                            <!-- <LoaderGridComponent v-show = "isShowLoader" /> -->
                        </tbody>
                    </table>
                </div>

                <!-- <PagingComponent 
                    v-bind:totalPage = "totalPage"
                    v-bind:totalRecord = "totalRecord"
                    v-on:btnPaging = "btnPaging"
                /> -->
            </div>
        </div>
    </div>
</template>

<script>


import axios from 'axios';

/* JS */
import {Resource} from '../../assets/js/common/resource'
import {Enum} from '../../assets/js/common/Enum'
import {CommonFunction} from '../../assets/js/common/commonFunction'

export default {

    data(){
        return{
            listIdSelectedRecord : [],
        }
    },

    props : {
        productCategories : {
            type : Array
        },
        
    },

    methods : {


        /**
         * Method thực hiện việc selected record phục vụ cho việc xóa dữ liệu
         * createdBy : NXHoang
        */
        btnSeclectedDelete : function(productCategoryId , event)
        {
            try {
                var self = this;
                this.isClickCheckbox = true;
                var checkbox =  event.target;
                var trSelected = self.$refs[productCategoryId];
                if(checkbox.checked)
                {
                    trSelected[0].classList.add("selected-record");
                    this.listIdSelectedRecord.push(productCategoryId);
                }else{
                    trSelected[0].classList.remove('selected-record')
                    var newArray = CommonFunction.arrayRemove(this.listIdSelectedRecord , productCategoryId);
                    this.listIdSelectedRecord = newArray;
                }
                self.$emit("insertProductCategoryIdToListId" , this.listIdSelectedRecord);

            } catch (error) {
                console.log(error)
            }
        },


        /**
         * Hàm thực hiện show dialog sản phẩm
         * CreatedBy : NXHoang (30/07/2022)
        */
        btnShowDialogToEdit : function(productCategoryId)
        {
            try {
                var me = this;
                me.$emit('passIsAddOrEdit' , Enum.FormModel.Edit)
                axios.get(Resource.API.Host + Resource.API.ProductCategory +  '/' + `${productCategoryId}`)
                .then((res) => {
                    console.log(res.data);
                    me.$emit('passProductCategoryEdit',  res.data)
                    me.$emit('showDialogProductCategory')
                })  
                .catch((res) => {
                    console.log(res)
                })
            } catch (error) {
                console.log(error)
            }
        },

        /**
         * Sự kiện khi hover vào một bản ghi trên table dùng để show nội dung cột chức năng
         * CreatedBy : NXHoang (19/11/2021)
         */
        showFeatureRecord : function(userId)
        {
            try {
                var me = this;
                var trSelected = me.$refs[userId];
                var feature = trSelected[0].querySelector('.feature');
                if(feature.classList.contains('hide-feature'))
                {
                    feature.classList.remove('hide-feature'); 
                }
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Sự kiện khi di chuyển chuột ra khỏi bản ghi (mouseleave) dùng để ẩn nội dung cột chức năng.
         * CreatedBy : NXHoang (19/11/2021)
        */
        hideFeatureRecord : function(productCategoryId)
        {
            try {
                var me = this;
                var trSelected = me.$refs[productCategoryId];
                var feature = trSelected[0].querySelector('.feature');
                feature.classList.add('hide-feature');
            } catch (error) {
                console.log(error);
            }
        },
    }
    
}
</script>

<style>

</style>





