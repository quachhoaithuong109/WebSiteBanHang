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
                                <th>Email</th>
                                <th >Số điện thoại</th>
                                <th >Địa chỉ</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            
                            <tr v-for = "(item, index) in users" :key="item.userId" :ref = "item.userId" @mouseover = "showFeatureRecord(item.userId)" @mouseleave = "hideFeatureRecord(item.userId)">
                                <th class="checkbox-table">
                                    <input type = "hidden" class = "input-hidden" />
                                    <input type="checkbox" class = "grid-checkbox">
                                </th>
                                <td class="stt-table align-center">
                                    {{index + 1}}
                                </td>
                                <td>{{item.userName}}</td>
                                <td>{{item.userEmail}}</td>
                                <td >{{item.userPhone}}</td>
                                <td>{{item.address}}</td>
                                <td class = "wrap-icon-feature ">
                                    <div class = "feature hide-feature"><!--hide-feature-->
                                        <div class = "edit-record wrap-icongrid-tooltip">
                                            <span class="grid-tooltiptext showTooltip-filterbar">Sửa</span>
                                        </div>
                                        <div class = "replication-record wrap-icongrid-tooltip"> 
                                            <span class="grid-tooltiptext showTooltip-filterbar tooltiptext-replication">Nhân bản</span>
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

export default {
    props : {
        users : {
            type : Array
        },
        
    },

    methods : {
        /**
         * Sự kiện khi hover vào một bản ghi trên table dùng để show nội dung cột chức năng
         * CreatedBy : NXHoang (19/11/2021)
         */
        showFeatureRecord : function(userId)
        {
            try {
                var me = this;
                var trSelected = me.$refs[userId];
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
        hideFeatureRecord : function(userId)
        {
            try {
                var me = this;
                var trSelected = me.$refs[userId];
                var feature = trSelected[0].querySelector('.feature');
                feature.classList.add('hide-feature');
            } catch (error) {
                console.log(error);
            }
        },
    }
    
}
</script>

<style>

</style>





