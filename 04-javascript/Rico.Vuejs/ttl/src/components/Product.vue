<template>
    <div class="product">
        <h3>{{msg}}，获取到的参数是：{{$route.params.id}}</h3>
    </div>
</template>

<script>
    export default{
        name:"product",
        data(){
            return {
                msg:"这里是product视图"
            }
        }
    }
</script>
<style scoped>
    h3{
        background-color:violet
    }
</style>