<template>
 
 <div>
 <!-- ============================================================== -->
    <!-- Preloader - style you can find in spinners.css -->
    <!-- ============================================================== -->
    <!-- <div class="preloader">
        <div class="lds-ripple">
            <div class="lds-pos"></div>
            <div class="lds-pos"></div>
        </div>
    </div>
     -->

    <div id="main-wrapper" data-navbarbg="skin6" data-theme="light" data-layout="vertical" data-sidebartype="full" data-boxed-layout="full">
        <header class="topbar" data-navbarbg="skin6">
            <HeaderComponent />
        </header>

        <aside class="left-sidebar" data-sidebarbg="skin5">
            <SidebarComponent />
        </aside>
        
        <div class="page-wrapper" style="display: block;">
            <ContentComponent />
        </div>
        
    </div>

</div>

</template>

<script>

import HeaderComponent from './components/HeaderComponent.vue'
import SidebarComponent from './components/SidebarComponent.vue'
import ContentComponent from './components/ContentComponent.vue'

export default {
  name: 'App',
  components: {
    HeaderComponent,
    SidebarComponent,
    ContentComponent
  },
  data(){
    return{
       
    }
  },
 
}
</script>

<style>

  @import url('./assets/main.css');
</style>
