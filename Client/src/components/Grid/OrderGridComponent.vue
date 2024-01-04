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
                                <th>Tên người dùng</th>
                                <th>Địa chỉ</th>
                                <th>SĐT</th>
                                <th>Ngày đặt</th>
                                <th>Tổng tiền</th>
                                <th>Trạng thái</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            
                            <tr v-for = "(item, index) in productOrders" :key="item.productOrderId" :ref = "item.productOrderId" @mouseover = "showFeatureRecord(item.productOrderId)" @mouseleave = "hideFeatureRecord(item.productOrderId)">
                                <th class="checkbox-table">
                                    <input type = "hidden" class = "input-hidden" />
                                    <input type="checkbox" class = "grid-checkbox" v-on:click = "btnSeclectedDelete(item.productOrderId,$event)">
                                </th>
                                <td class="stt-table align-center">
                                    {{index + 1}}
                                </td>
                                <td>{{item.userName}}</td>
                                <td>{{item.userPhone}}</td>
                                <td>{{item.userAddress}}</td>
                                <td>{{formatDate(item.orderDate)}}</td>
                                <td>{{formatMoney(item.totalPrice)}}</td>
                                <td>    
                                    <span class="badge badge-success">{{checkStatus(item.status)}}</span>
                                </td>

                                <td class = "wrap-icon-feature ">
                                    <div class = "feature hide-feature">
                                        <div class = "edit-record wrap-icongrid-tooltip" v-on:click = "btnShowDialogToEdit(item.productOrderId)">
                                            <span class="grid-tooltiptext showTooltip-filterbar">Sửa</span>
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
/* File Javascript */
import { CommonFunction } from '../../assets/js/common/commonFunction'
import {Resource} from '../../assets/js/common/resource'

export default {
    props : {
        productOrders : {
            type : Array
        },
    },

    methods : {


        /**
         * Hàm thực hiện show dialog sản phẩm
         * CreatedBy : NXHoang (30/07/2022)
        */
        btnShowDialogToEdit : function(productOrderId)
        {
            try {
                var me = this;
                axios.get(Resource.API.Host + Resource.API.ProductOrder + "/GetProductOrderDetail" +  '/' + `${productOrderId}`)
                .then((res) => {
                    console.log(res.data);
                    me.$emit('passOrderDetail',  res.data)
                    me.$emit('showDialogOrder')
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
        showFeatureRecord : function(productOrderId)
        {
            try {
                var me = this;
                var trSelected = me.$refs[productOrderId];
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
        hideFeatureRecord : function(productOrderId)
        {
            try {
                var me = this;
                var trSelected = me.$refs[productOrderId];
                var feature = trSelected[0].querySelector('.feature');
                feature.classList.add('hide-feature');
            } catch (error) {
                console.log(error);
            }
        },


        /**
         * Hàm thực hiện check còn sản phẩm hay thiếu sản phẩm
         * CreatedBy : NXHoang (30/07/2022)
        */
        checkStatus : function(status)
        {
            if(status == 1)
            {
                return Resource.VN.checkStatus.Option2;
            }
            return Resource.VN.checkStatus.Option1;
        },

        /**
         * Hàm thực hiện format money
         * CreatedBy : NXHoang (30/07/2022)
        */
        formatMoney : function(value){
            var moneyFormated = CommonFunction.formatMoney(value)
            return moneyFormated
        },

        formatDate : function(value)
        {
            var date = CommonFunction.formatDate(value)
            return date
        }

    }

}
</script>

<style>

</style>