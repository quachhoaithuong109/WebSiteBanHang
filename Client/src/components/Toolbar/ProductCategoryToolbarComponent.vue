<template>
  <div class="row filter-toobar-product">
        <div class="col-5 align-self-center">
            <h4 class="page-title">Danh mục sản phẩm</h4>
        </div>
        <div class="col-7">
            <div class="wrap-button-header">
                <button type="button" class="btn btn-success btn-add-product"  v-on:click = "addProductClick">
                    <span>
                        <i class="fa fa-plus" aria-hidden="true"></i>
                    </span>
                    Thêm danh mục 
                </button>

                <button type="button" class="btn btn-danger btn-delete-product"  v-on:click = "btnDeleteRecord">
                    <span>
                        <i class="fa fa-trash" aria-hidden="true"></i>
                    </span>
                    Xóa danh mục
                </button>

            </div>
        </div>
    </div>
</template>

<script>
export default {
    methods : {
        /**
         * Method xử lý khi click vào button thêm sản phẩm
         * createdBy : NXHoang 
        */
        addProductClick : function(){
            this.$emit('showDialogProductCategory')
            this.$emit('setIsProductCategory')
        },

        /** 
         * Sự kiện dùng để xóa các bản ghi được chọn 
         * CreatedBy : NXHoang
        */
        btnDeleteRecord : function()
        {
            this.$emit("btnDeleteRecord");    
        },  


    }
}
</script>

<style>

</style>