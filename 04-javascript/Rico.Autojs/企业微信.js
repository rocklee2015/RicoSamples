var max=19,min=18;
var minute=Math.floor(Math.random()*(max-min)+min);
var morningTime="12:"+minute;//打开时间
//var morningTime="11:30";//打开时间
function isMorningTime() {
    var now =new Date();
    var hour=now.getHours();
    var minu=now.getMinutes();
    var targetTime=morningTime.split(":");
    tLog("当前时间："+hour+":"+minu);
    if(Number(targetTime[0])==hour && Math.abs(Number(targetTime[1])-minu)<=5){
        return true;
    }else{
        return false;
    }
}
function tLog(msg) {
    //toast(msg);
    console.log(msg)
}

function mainEntrence(){
    var max=14,min=0;
    var minute=Math.floor(Math.random()*(max-min)+min);
    sleep(1000*60*minute);
    launchApp("企业微信");

}
mainEntrence();