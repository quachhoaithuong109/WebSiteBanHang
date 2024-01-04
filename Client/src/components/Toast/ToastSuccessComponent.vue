<template lang="">
    <div class="toast-model">
        <div class="m-toast success-toast">
            <div class="icon-toast toast-icon-success">
                <i class="fa fa-check" aria-hidden="true"></i>
            </div>
            <div class="content-toast">{{messageSuccess}}</div>
        </div>
    </div>
</template>
<script>
export default {
    props : ['messageSuccess']
}
</script>
<style lang="">
    
</style>