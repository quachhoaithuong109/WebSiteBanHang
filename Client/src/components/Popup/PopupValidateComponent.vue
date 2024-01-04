<template lang="">
    <div class="dialog-confirm-model">
        <div class="wrap-dialog-confirm"></div>
        <div class="m-dialog-confirm">

            <div class="content-dialog-confirm">
                <div class="icon-dialog-confirm">
                    <i class="fa fa-exclamation-triangle" aria-hidden="true"></i>
                </div>
                <div class="text-dialog-confirm" v-html = "messageNotValid"></div>
            </div>
            <div class="button-dialog-confirm">
                <button class="m-btn m-btn-delete btn-delete-record" v-on:click = "btnHideDialogNotValid">Hủy bỏ</button>
            </div>
        </div>
    </div>
</template>
<script>

export default {
    data() {
        return {

        }
    },
    methods: {
        /**
         * Method xác nhận việc hủy đóng popup
         * CreatedBy : NXHoang (18/11/2021)
        */
        btnHideDialogNotValid : function()
        {
            this.$emit("btnHideDialogNotValid")
        },
    },
    props : {
        messageNotValid : {
            type :String
        }
    },
}
</script>
<style lang="">

</style>