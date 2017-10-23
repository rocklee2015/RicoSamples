<template>
    <div>
        <h3>{{msg}}，获取到的参数是：{{$route.params.id}}</h3>
    </div>
</template>

<script>
    export default{
        name:"user",
        data(){
            return {
                msg:"这里是user视图"
            }
        }
    }
</script>
<style scoped>
    h3{
        background-color:gold
    }
</style>