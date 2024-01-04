<template>
    <div class="row filter-toobar-product">
        <div class="col-5 align-self-center">
            <h4 class="page-title">Danh sách đơn hàng</h4>
        </div>
        <div class="col-7">
            <div class="wrap-button-header">

                <button type="button" class="btn btn-danger btn-delete-product"  v-on:click = "btnDeleteRecord">
                    <span>
                        <i class="fa fa-trash" aria-hidden="true"></i>
                    </span>
                    Xóa đơn hàng
                </button>

            </div>
        </div>
    </div>
</template>

<script>
export default {

}
</script>

<style>

</style>