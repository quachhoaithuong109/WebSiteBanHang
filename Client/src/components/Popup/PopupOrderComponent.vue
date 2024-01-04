<template>
   <div class="m-popup toggle-popup">
        <div class="wrap-popup"></div>
        <div class="popup-info-assets">
            <div class="header-popup">
                Thông tin chi tiết đơn hàng
                <button class="close-popup" id="close-popup" v-on:click="hidedDialogOrder"></button>
            </div>
            <div class="content-popup" ref="contentPopup">
                <div class="row grid-product">
        <div class="col-12">
            <div class="grid">
                <div class="content-grid">
                    <table class="table-grid-load">
                        <thead class="thead-table">
                            <tr>
                                <th class="stt-table align-center m-wrap-tooltip">
                                    STT
                                </th>
                                <th>Tên sản phẩm</th>
                                <th>Hình ảnh</th>
                                <th class="align-right">Đơn giá</th>
                                <th class="align-right">Số lượng</th>
                            </tr>
                        </thead>
                        <tbody>
                            
                            <tr v-for = "(item, index) in orderDetail" :key="index">
                                <td class="stt-table align-center">
                                    {{index + 1}}
                                </td>
                                <td>{{item.productName}}</td>
                                <td class="image-table-product">
                                    <!-- <img src="../assets/images/Products/DienThoai/iphone-13-01.jpg" /> -->
                                    <img :src = "renderSrc(item.image,item.typeProduct)" />
                                </td>
                                <td class="align-right">{{formatMoney(item.productPrice)}}</td>
                                <td class="align-right">{{item.quantity}}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
        </div>
            <div class="footer-popup">
                <div class="wrap-button-footer">
                    <button type="button" class="m-btn-cancel" id="btn-close-popup" v-on:click = "hidedDialogOrder">
                        Hủy
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import {Resource} from '../../assets/js/common/resource' 

/* File Javascript */
import { CommonFunction } from '../../assets/js/common/commonFunction'

export default {
    props:{
        orderDetail : {
            type : Array
        }
    },
    methods : {


        /**
         * Method thực hiện close Popup form chi tiết sản phẩm
         * CreatedBy : NXHoang 
        */
        hidedDialogOrder(){
            this.$emit('hidedDialogOrder');
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