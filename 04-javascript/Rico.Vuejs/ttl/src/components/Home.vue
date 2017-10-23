<!--首页组件-->
<template>
    <div class="home">
        <h3>{{msg}}</h3>
    </div>
</template>

<script>
    export default {
        name:"home",
        data(){
            return {
                msg:"这里是home视图"
            }
        }
    }
</script>

<style scoped>
    h3{
        background-color: #c5c5c5
    }
</style>