<template>
    <div>
        <UserToolbarComponent />
        <UserGridComponent 
            v-bind:users = "users"
        />
    </div>
</template>

<script>

/* Import Component */
import UserToolbarComponent from '../components/Toolbar/UserToolbarComponent.vue'
import UserGridComponent from '../components/Grid/UserGridComponent.vue'

/* import js */
import {Resource} from '../assets/js/common/resource'

/* Import library */
import axios from 'axios'


export default {
    name : "user-component",
    components : {
        UserToolbarComponent,
        UserGridComponent
    },
    data(){
        return{
            users : [],
            isShowLoader : false,
            currentPage : 1
        }
    },

    methods : {
         /**
         * Lấy danh sách người dùng
         * CreatedBy : NXHoang (04/08/2022)
        */
        getData(){
            var me = this;
            this.isShowLoader = true;
            // axios.get(Resource.API.Host + Resource.API.GetProductApi)
            axios.get(Resource.API.Host + Resource.API.User + Resource.API.searchUser(Resource.SearchPaging.textSearch, Resource.SearchPaging.PageSize ,  me.currentPage))
            .then(res => {
                this.isShowLoader = false;
                me.users = res.data.data;
                // me.totalPage = res.data.totalPage;
                // me.totalRecord = res.data.totalRecord;
            })
            .catch(error => {
                // this.isShowLoader = false;
                console.log(error)
            })
        },
    },

    created() {
        this.getData();
    },
}
</script>

<style>

</style>