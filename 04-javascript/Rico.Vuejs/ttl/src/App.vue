<!--<template>
  <div id="app">
    <img src="./assets/logo.png">
    <hello></hello>
  </div>
</template>

<script>
import Hello from './components/Hello'

export default {
  name: 'app',
  components: {
    Hello
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>-->

<template>
    <div id="app">
        <nav class="top-menu">
            <ul>
              <!--遍历li，输出顶部工具栏-->
               <li v-for="item in menulist">
                  <router-link :to="item.url">{{item.name}}</router-link>
               </li>
            </ul>
        </nav>
        <hr>
        <div>
          <router-view></router-view>
        </div>
    </div>
</template>

<script>
    export default {
        name:"app",
        data:function (){
            return {
                menulist:[
                    {"name":"首页",url:"/home"},
                    {"name":"用户",url:"/user/18"},
                    {"name":"产品",url:"/product/20"},
                ]
            }
        }
    }
</script>

<style>
    #app {

    }
    .top-menu ul, .top-menu li {
      list-style: none;
    }
    .top-menu {
      overflow: hidden;
    }
    .top-menu li {
      float: left;
      width: 100px;
    }
</style>