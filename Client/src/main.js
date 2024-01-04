import { createApp } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'
import {routes} from './router'
import App from './App.vue'

const router = new createRouter({
    history:createWebHistory(),
    routes
})


const app = createApp(App);
app.use(router);
app.mount('#app')

// createApp(App).mount('#app')

// new Vue({
//     router,
//     render: h => h(App),
// }).$mount('#app')
