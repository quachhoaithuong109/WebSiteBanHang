<template lang="">
    <div v-bind:class = "customClass"><!-- class="paging"  -->

        
        <div class="list-page">
          
                   <paginate
                    :page-count="totalPage"
                    :page-range="3"
                    :margin-pages="2"
                    :click-handler="btnPaging"
                    :prev-text="''"
                    :next-text="''"
                    :container-class="'pagination'"
                    :page-class="'page-item'"
                    />     

        </div>
    </div>
</template>
<script>

/* Important Component */
import Paginate from 'vuejs-paginate-next';

export default {
    components : {
        Paginate
    },
    data() {
        return {
            
        }
    },
    props : {
        totalPage : {
            type : Number
        },
        totalRecord : {
            type:Number
        }
        // customClass : {
        //     type : String
        // }
    },
    

    methods: {

        btnPaging : function (currentPage){
            this.$emit("btnPaging" , currentPage)
        }
    },

}
</script>
<style lang="css">
  /* Adopt bootstrap pagination stylesheet. */
  @import "https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css";

</style>