<template>
    <div class="dialog-confirm-model">
        <div class="wrap-dialog-confirm"></div>
        <div class="m-dialog-confirm">
            
            <div class="content-dialog-confirm">
                <div class="icon-dialog-confirm"> 
                    <i class="fa fa-exclamation-triangle" aria-hidden="true"></i>
                </div>
                <div class="text-dialog-confirm" v-html = "messageConfirm"></div>
            </div>
            <div class="button-dialog-confirm" v-show = "isCancelSaveConfirm">
                <button class="m-btn-cancel btn-out-line" v-on:click = "btnNotHideDialogConfirm">Không</button>
                <button class="m-btn m-btn-delete btn-delete-record" v-on:click = "btnHideDialogConfirm">Hủy bỏ</button>
            </div>
            <div class="button-dialog-confirm" v-show = "isDeleteConfirm">
                <button class="m-btn-cancel btn-out-line" v-on:click = "btnNotHideDialogConfirm">Không</button>
                <button class="m-btn m-btn-delete btn-delete-record" v-on:click = "btnConfirmDelete">Xóa</button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props : {
        messageConfirm : {
            type : String
        },
        isCancelSaveConfirm : {
            type : Boolean
        },
        isDeleteConfirm : {
            type : Boolean
        }
    },

    methods : {

        /**
         * Method xác nhận việc đóng popup thêm/sửa sản phẩm
         * CreatedBy : NXHoang 
        */
        btnHideDialogConfirm :function()
        {
            this.$emit("btnHideDialogConfirm")
        },

        /**
         * Method xác nhận việc hủy đóng popup thêm/sửa sản phẩm
         * CreatedBy : NXHoang
        */
        btnNotHideDialogConfirm : function()
        {
            this.$emit("btnNotHideDialogConfirm")
        },

        /**
         * Method dùng để xóa sản phẩm khi người dùng xác nhận xóa
         * CreatedBy : NXHoang 
        */
        btnConfirmDelete : function()
        {
            this.$emit("btnConfirmDelete");
        }


    }
}
</script>

<style>

</style>