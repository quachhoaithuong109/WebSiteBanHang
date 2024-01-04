<template>
    <div>
        <OrderToolbarComponent />
        <OrderGridComponent 
            v-bind:productOrders="productOrders" 
            v-on:showDialogOrder = "showDialogOrder"
            v-on:passOrderDetail = "passOrderDetail"
        />

        <PopupOrderComponentVue
            v-if="showDialog"
            v-bind:orderDetail = "orderDetail"
            v-on:hidedDialogOrder = "hidedDialogOrder"
        />

    </div>
</template>

<script>


import axios from 'axios'
/* JS */

import {Resource} from '../../src/assets/js/common/resource'

/* import component */
import OrderToolbarComponent from '../components/Toolbar/OrderToolbarComponent.vue'
import OrderGridComponent from '../components/Grid/OrderGridComponent.vue'
import PopupOrderComponentVue from './Popup/PopupOrderComponent.vue'

export default {
    components : {
        OrderToolbarComponent,
        OrderGridComponent,
        PopupOrderComponentVue
    },

    data(){
        return{
            productOrders: [],
            isShowLoader : false,
            currentPage : 1,
            showDialog : false,
            orderDetail : []
        }
    },

    methods : {

        /**
         * Lấy danh sách danh mục sản phẩm
         * CreatedBy : NXHoang
        */
        getData(){
            var me = this;
            this.isShowLoader = true;
            axios.get(Resource.API.Host + Resource.API.ProductOrder + Resource.API.searchProductOrder(Resource.SearchPaging.textSearch, Resource.SearchPaging.PageSize ,  me.currentPage))
            .then(res => {
                this.isShowLoader = false;
                me.productOrders = res.data.data;
            })
            .catch(error => {
                this.isShowLoader = false;
                console.log(error)
            })
        },

        passOrderDetail : function(orderDetail)
        {   
            this.orderDetail=  JSON.parse(JSON.stringify(orderDetail));
        },

        showDialogOrder : function()
        {
            this.showDialog = true;
        },

        hidedDialogOrder : function()
        {
            this.showDialog = false;
        }
    },

    created() {
        this.getData();
    },
}
</script>

<style>

</style>