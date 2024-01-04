//Định nghĩa router đến các component

import ProductComponent from './components/ProductComponent.vue'
import UserComponent from './components/UserComponent.vue'
import ProductCategoryComponent from './components/ProductCategoryComponent.vue'
import OrderComponent from './components/OrderComponent.vue'
export const routes = [
    {path : '/' , name : "Danh sách sản phẩm" , component : ProductComponent},
    {path : '/products' , name : "Danh sách sản phẩm" , component : ProductComponent},
    {path : '/productCategories' , name : "Danh mục sản phẩm" , component : ProductCategoryComponent},
    {path : '/Users' , name : "Danh sách người dùng" , component : UserComponent},
    {path : '/Orders' , name : "Danh sách đơn hàng" , component : OrderComponent}
]
