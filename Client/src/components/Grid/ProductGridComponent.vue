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
                                <!-- <th>Mã sản phẩm</th> -->
                                <th>Hình ảnh</th>
                                <th>Tên sản phẩm</th>
                                <th>Loại sản phẩm</th>
                                <th class="align-right align-right-quantity">Số lượng</th>
                                <th class="align-right">Đơn giá</th>
                                <th class="align-right">Khuyến mại</th>
                                <th class = "freature-grid status-grid">Trạng thái</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for = "(item, index) in products" :key="item.productId" :ref = "item.productId" @mouseover = "showFeatureRecord(item.productId)" @mouseleave = "hideFeatureRecord(item.productId)">
                                <th class="checkbox-table">
                                    <input type = "hidden" class = "input-hidden" />
                                    <input type="checkbox" class = "grid-checkbox" v-on:click = "btnSeclectedDelete(item.productId,$event)">
                                </th>
                                <td class="stt-table align-center">
                                    {{index + 1}}
                                </td>
                                <!-- <td>
                                    {{item.productName}}
                                </td> -->
                                <td class="image-table-product">
                                    <!-- <img src="../assets/images/Products/DienThoai/iphone-13-01.jpg" /> -->
                                    <img :src = "renderSrc(item.image,item.typeProduct)" />
                                </td>
                                <td>{{item.productName}}</td>
                                <td>{{item.categoryName}}</td>
                                <td class="align-right align-right-quantity">{{item.quantity}}</td>
                                <td class="align-right">{{formatMoney(item.price)}}</td>
                                <td class="align-right">{{formatMoney(item.promotionPrice)}}</td>
                                <td>    
                                    <span class="badge badge-success">{{checkHaveQuantity(item.quantity)}}</span>
                                </td>
                                <td class = "wrap-icon-feature ">
                                    <div class = "feature hide-feature"><!--hide-feature-->
                                        <div class = "edit-record wrap-icongrid-tooltip" v-on:click = "btnShowDialogToEdit(item.productId)">
                                            <span class="grid-tooltiptext showTooltip-filterbar">Sửa</span>
                                        </div>
                                        <div class = "replication-record wrap-icongrid-tooltip"> 
                                            <span class="grid-tooltiptext showTooltip-filterbar tooltiptext-replication">Nhân bản</span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <LoaderGridComponent v-show = "isShowLoader" />
                        </tbody>
                    </table>
                </div>

                <PagingComponent 
                    v-bind:totalPage = "totalPage"
                    v-bind:totalRecord = "totalRecord"
                    v-on:btnPaging = "btnPaging"
                />
            </div>
        </div>
    </div>
</template>

<script>

import axios from 'axios'

/* Component */
import PagingComponent from '../Base/PagingComponent.vue'
import LoaderGridComponent from '../Base/LoaderGridComponent.vue'

/* File Javascript */
import { CommonFunction } from '../../assets/js/common/commonFunction'
import {Resource} from '../../assets/js/common/resource'
import {Enum} from '../../assets/js/common/Enum'

export default {
    data(){
        return{
            isClickCheckbox : false,
            listIdSelectedRecord : [],
        }
    },
    props : {
        products : {
            type : Array
        },

        isShowLoader : {
            type : Boolean
        },

        totalPage : {
            type : Number
        },  
        totalRecord : {
            type : Number
        },
        currentPage : {
            type : Number
        },
        
    },

    components : {
        LoaderGridComponent,
        PagingComponent
    },

    methods:{

         /**
         * Sự kiện khi hover vào một bản ghi trên table dùng để show nội dung cột chức năng
         * CreatedBy : NXHoang (19/11/2021)
         */
        showFeatureRecord : function(productId)
        {
            try {
                var me = this;
                var trSelected = me.$refs[productId];
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
        hideFeatureRecord : function(productId)
        {
            try {
                var me = this;
                var trSelected = me.$refs[productId];
                var feature = trSelected[0].querySelector('.feature');
                feature.classList.add('hide-feature');
            } catch (error) {
                console.log(error);
            }
        },

        /**
         * Sự kiện kích hoạt khi chuyển sang trang khác
         * createdBy : NXHoang 
         * 
        */
        btnPaging : function(currentPage)
        {
            this.$emit("btnPaging" , currentPage);
        },

        
        /**
         * Method thực hiện việc selected record phục vụ cho việc xóa dữ liệu
         * createdBy : NXHoang
        */
        btnSeclectedDelete : function(productId , event)
        {
            try {
                var self = this;
                this.isClickCheckbox = true;
                var checkbox =  event.target;
                var trSelected = self.$refs[productId];
                if(checkbox.checked)
                {
                    trSelected[0].classList.add("selected-record");
                    this.listIdSelectedRecord.push(productId);
                }else{
                    trSelected[0].classList.remove('selected-record')
                    var newArray = CommonFunction.arrayRemove(this.listIdSelectedRecord , productId);
                    this.listIdSelectedRecord = newArray;
                }
                self.$emit("insertProductIdToListId" , this.listIdSelectedRecord);

            } catch (error) {
                console.log(error)
            }
        },

        /**
         * Hàm thực hiện show dialog sản phẩm
         * CreatedBy : NXHoang (30/07/2022)
        */
        btnShowDialogToEdit : function(productId)
        {
            try {
                var me = this;
                me.$emit('passIsAddOrEdit' , Enum.FormModel.Edit)
                axios.get(Resource.API.Host + Resource.API.Product +  '/' + `${productId}`)
                .then((res) => {
                    me.$emit('passProductEdit',  res.data)
                    me.$emit('showDialogProduct')
                })  
                .catch((res) => {
                    console.log(res)
                })
            } catch (error) {
                console.log(error)
            }
        },

        /**
         * Hàm thực hiện check còn sản phẩm hay thiếu sản phẩm
         * CreatedBy : NXHoang (30/07/2022)
        */
        checkHaveQuantity : function(quantity)
        {
            if(quantity == 0 || quantity == null)
            {
                return Resource.VN.checkHaveQuantity.NotHaveQuantity;
            }
            return Resource.VN.checkHaveQuantity.HaveQuantity;
        },

        /**
         * Hàm thực hiện format money
         * CreatedBy : NXHoang (30/07/2022)
        */
        formatMoney : function(value){
            var moneyFormated = CommonFunction.formatMoney(value)
            return moneyFormated
        },

        renderSrc : function(image,typeProduct)
        {
            let src = "";

            switch(typeProduct) {
                case Resource.VN.TypeProduct.Phone:
                    src = Resource.VN.SrcImage.Phone + image;
                    break;
                case Resource.VN.TypeProduct.Laptop:
                    src = Resource.VN.SrcImage.Laptop + image;
                    break;
                case Resource.VN.TypeProduct.Tablet:
                    src = Resource.VN.SrcImage.Tablet + image;
                    break;
                // case Resource.VN.TypeProduct.Tivi:
                //     src = Resource.VN.SrcImage.Tivi + image;
                //     break;
                default:
                    src = Resource.VN.SrcImage.Default + image;
                    break;
            }
            return src;

        }
    }
}
</script>

<style>

</style>





