// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'

// 引入路由组件、自定义路由组件
import VueRouter from "vue-router"    
import router from "./router"

//使用路由组件
Vue.use(VueRouter)



/* eslint-disable no-new */
new Vue({
  el: '#app',
  template: '<App/>',
  components: { App },
  router:router
})
