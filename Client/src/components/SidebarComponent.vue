<template>
    <div class="scroll-sidebar">
        <!-- Sidebar navigation-->
        <nav class="sidebar-nav">
            <ul id="sidebarnav">
                <li class="sidebar-item">
                    <router-link class="sidebar-link waves-effect waves-dark sidebar-link"  aria-expanded="false" to="/products">
                        <i class="fa fa-product-hunt" aria-hidden="true"></i>
                        <span class="hide-menu">Danh sách sản phẩm</span>
                    </router-link>
                </li>   
                <li class="sidebar-item">
                    <router-link class="sidebar-link waves-effect waves-dark sidebar-link"  aria-expanded="false" to="/productCategories">
                        <i class="mdi mdi-av-timer"></i>
                        <span class="hide-menu">Danh sách danh mục</span>
                    </router-link>
                </li>
                <li class="sidebar-item">
                    <!-- <a class="sidebar-link waves-effect waves-dark sidebar-link" href="pages-profile.html" aria-expanded="false">
                        <i class="mdi mdi-account-network"></i>
                        <span class="hide-menu">Danh sách người dùng</span>
                    </a> -->

                    <router-link class="sidebar-link waves-effect waves-dark sidebar-link" aria-expanded="false" to="/Users">
                        <i class="fa fa-user" aria-hidden="true"></i>
                        <span class="hide-menu">Danh sách người dùng</span>
                    </router-link>
                </li>
                <li class="sidebar-item">
                    <router-link class="sidebar-link waves-effect waves-dark sidebar-link" to="/Orders"
                        aria-expanded="false">
                        <i class="fa fa-id-card-o" aria-hidden="true"></i>
                        <span class="hide-menu">Đơn hàng</span>
                    </router-link>
                </li>
               
                <li class="sidebar-item">
                    <a class="sidebar-link waves-effect waves-dark sidebar-link" href="error-404.html"
                        aria-expanded="false">
                        <i class="mdi mdi-alert-outline"></i>
                        <span class="hide-menu">404</span>
                    </a>
                </li>
            </ul>
        </nav>
        <!-- End Sidebar navigation -->
    </div>
</template>

<script>


export default {
  name: 'sidebar-component',
  components: {
    
  },
  data(){
    return{
       
    }
  },
 
}
</script>
