
var myEnergeType=["����֧��","����","������","������Ʊ","���繺Ʊ","������Ʊ","����ɷ�","ETC�ɷ�","���ӷ�Ʊ","��ɫ�칫","���㽻��","ԤԼ�Һ�"];
var morningTime="07:20";//�Լ��˶���������ʱ��
unlock();
sleep(1000);
mainEntrence();
 
//����
function unlock(){
    if(!device.isScreenOn()){
    	//������Ļ
        device.wakeUp();
        sleep(1000);
			//������Ļ�������������
        swipe(500, 1900, 500, 1000, 1000);
        sleep(1000);
        
       //�����Ĵ� 1 ������Ϊ1111�� ���ּ�1����������Ϊ��200,1000��
        click(200,1000);
        sleep(500);
       
        click(200,1000);
        sleep(500);
        
        click(200,1000);
        sleep(500);
        
        click(200,1000);
        sleep(500);
    
    }
}
function tLog(msg) {
    toast(msg);
    console.log(msg)
}
/**
 * ��ȡȨ�޺����ò���
 */
function prepareThings(){
    setScreenMetrics(1080, 1920);
    //�����ͼ
   if(!requestScreenCapture()){
        tLog("�����ͼʧ��");
        exit();
    }
    
}
/**
 * ���ð������� ���ű�ִ��ʱ�������� �˳��ű�
 */
function registEvent() {
    //���ð�������
    events.observeKey();
    //���������ϼ�����
    events.onKeyDown("volume_down", function(event){
        tLog("�ű��ֶ��˳�");
        exit();
    });
}
/**
 * ��ȡ��ͼ
 */
function getCaptureImg(){
    var img0 = captureScreen();
    if(img0==null || typeof(img0)=="undifined"){
        tLog("��ͼʧ��,�˳��ű�");
        exit();
    }else{
        return img0;
    }
}
/**
 * Ĭ�ϳ��������ʾ����
 */
function defaultException() {
    tLog("����ǰ����״̬����Ԥ��,�ű��˳�");
    exit();
}
/**
 * �ȴ������ռ�����ҳ��,����δ�ҵ�ָ����������ķ�ʽ,�ȴ�ҳ��������
 */
function waitPage(type){
    // �ȴ������Լ���������ҳ
    if(type==0){
        desc("��Ϣ").findOne();
    }
    // �ȴ��������˵�������ҳ
    else if(type==1){
        desc("��ˮ").findOne();
    }
    //�ٴ��ݴ���
    sleep(3000);
}
/**
 * ��֧������ҳ��������ɭ���ҵ���ҳ
 */
function enterMyMainPage(){
    launchApp("֧����");
    tLog("�ȴ�֧��������");
    sleep(2000)
    click("����ɭ");
    //�ȴ������Լ�����ҳ
    waitPage(0);
}
/**
 * �������а�
 */
function enterRank(){
    tLog("�������а�");
    //��������Ͷ�
    swipe(520,1860,520,100,1000);
    swipe(520,1860,520,100,1000);
    swipe(520,1860,520,100,1000);
    
    clickByDesc("�鿴�������",0,true,"����δ�ҵ����а����,�ű��˳�");
    //�ȴ����а���ҳ����
    sleep(1000)
   
}
/**
 * �����а��ȡ���ռ����еĵ��λ��
 * @returns {*}
 */
function  getHasEnergyfriend(type) {
    var img = getCaptureImg();
    var p=null;
    if(type==1){
        //img ��ͼƬ
        //"#30bf6c" ��һ����ɫ
        //[0, 33, "#30bf6c"] �ڶ���ɫ�������������
        //[34,45, "#ffffff"] ��������ɫ�������������
        //region: [1030, 100, 1, 1700] ��һ����ɫ�ļ������1030��100Ϊ��ʼ���꣬1��1700Ϊ�����ȣ�����
        p = images.findMultiColors(img, "#30bf6c",[[60, 0, "#30bf6c"], [46,45, "#ffffff"]], {
            region: [1018, 100, 1, 1700]
        });
    }
    if(p!=null){
        return p;
    }else {
        return null;
    }
}
/**
 * �ж��Ƿ�������а��Ѿ�����
 * @returns {boolean}
 */
function isRankEnd() {
    if(descEndsWith("û�и�����").exists()){
        var b=descEndsWith("û�и�����").findOne();
        var bs=b.bounds();
        if(bs.centerY()<1920){
            return true;
        }
    }
    return false;
}
/**
 * �����а�ҳ��,ѭ�����ҿ��ռ�����
 * @returns {boolean}
 */
function enterOthers(){
    tLog("��ʼ������а�");
    var i=1;
    var ePoint=getHasEnergyfriend(1);
    //ȷ����ǰ�����������а����
    while(ePoint==null && textEndsWith("�������а�").exists()){
        swipe(520,1800,520,300,1000);
        sleep(3000);
        ePoint=getHasEnergyfriend(1);
        i++;
        //����Ƿ����а������
        if(isRankEnd()){
            return false;
        }
        //�������32�ζ�δ��⵽���ռ�����,�������ֹͣ����(���ڳ�������������а����,���ж��˽������,�����Ѿ����������������)
        else if(i>32){
            tLog("������ܳ���,����"+i+"��δ��⵽���ռ�����");
            exit();
        }
    }
    if(ePoint!=null){
        
        //���λ�������ͼ�������
        tLog(ePoint.x,ePoint.y);
        click(ePoint.x,ePoint.y+20);
        waitPage(1);
        clickByDesc("����ȡ",80);
        //��ȥ�ռ����,�ݹ����enterOthers
        back();
        sleep(2000);
        var j=0;
        //�ȴ����غ������а�
        if(!textEndsWith("�������а�").exists() && j<=5){
            sleep(2000);
            j++;
        }
        if(j>=5){
            defaultException();
        }
        enterOthers();
    }else{
        defaultException();
    }
}
/**
 * ��������ֵ ���
 * @param energyType
 * @param noFindExit
 */
function clickByDesc(energyType,paddingY,noFindExit,exceptionMsg){
    if(descEndsWith(energyType).exists()){
        descEndsWith(energyType).find().forEach(function(pos){
            var posb=pos.bounds();
            click(posb.centerX(),posb.centerY()-paddingY);
            sleep(2000);
        });
    }else{
        if(noFindExit!=null && noFindExit){
            if(exceptionMsg !=null){
                tLog(exceptionMsg);
                exit();
            }else{
                defaultException();
            }
        }
    }
}
/**
 * ����textֵ ��� * @param energyType * @param noFindExit
 */
function clickByText(energyType,noFindExit,exceptionMsg){
    if(textEndsWith(energyType).exists()){
        textEndsWith(energyType).find().forEach(function(pos){
            var posb=pos.bounds();
            click(posb.centerX(),posb.centerY()-60);
        });
    }else{
        if(noFindExit!=null && noFindExit){
            if(exceptionMsg !=null){
                tLog(exceptionMsg);
                exit();
            }else{
                defaultException();
            }
        }
    }
}
/**
 * ������������,�ռ��Լ�������
 */
function collectionMyEnergy(){
    var energyRegex=generateCollectionType();
    var checkInMorning=false;
    //���������7��20�����ҵĻ�.�ȴ���ҳ�������� ÿ��һ����һ��
    while(isMorningTime() && descEndsWith("����").exists()){
        if (!checkInMorning){
            tLog("�ȴ��˶�����������...");
            checkInMorning=true;
        }
        descEndsWith("����").find().forEach(function(pos){
            var posb=pos.bounds();
            click(posb.centerX(),posb.centerY()-80);
            sleep(1500);
        });
    }
    if(checkInMorning){
        tLog("�˶������ռ����");
    }
    if(descMatches(energyRegex).exists()){
        if(!checkInMorning){
            tLog("��ֹС������ʾ�ڵ�,�ȴ���");
            sleep(3000);
        }
        //�������һ�������⣺���sleepʱ��̵Ļ����ͻ����ѭ�����������У�ѭ��֮��Ĵ���Ҳ�����У��о��������첽������ԭ����
       descMatches(energyRegex).find().forEach(function(pos){
            var posb=pos.bounds();
            //tLog( posb.centerX());
            click(posb.centerX(),posb.centerY()-100);
            sleep(3000);
        });
    }
    tLog("�Լ������ռ����");
    sleep(1000);
}
/**
 * �����󷵻���ҳ��
 */
function whenComplete() {
    tLog("����");
    back();
    sleep(1500);
    back();
    exit();
}
/**
 * ���������������������ҵ�����������������ַ���
 * @returns {string}
 */
function generateCollectionType() {
    var regex="/";
    myEnergeType.forEach(function (t,num) {
        if(num==0){
            regex+="(\\s*"+t+"$)";
        }else{
            regex+="|(\\s*"+t+"$)";
        }
    });
    regex+="/";
    return regex;
}
function isMorningTime() {
    var now =new Date();
    var hour=now.getHours();
    var minu=now.getMinutes();
    var targetTime=morningTime.split(":");
    if(Number(targetTime[0])==hour && Math.abs(Number(targetTime[1])-minu)<=2){
        return true;
    }else{
        return false;
    }
}
//���������
function mainEntrence(){
    //ǰ�ò���
    prepareThings();
    //ע�������°����˳��ű�����
    registEvent();
    //����ҳ��������ɭ����ҳ
    enterMyMainPage();
    //�ռ��Լ�������
    collectionMyEnergy();
    //�������а�
    enterRank();
    //�����а����Ƿ��к��е����������ռ�
    enterOthers();
    //�����󷵻���ҳ��
    whenComplete();
}
 
