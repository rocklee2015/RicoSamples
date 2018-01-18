<Query Kind="SQL">
  <Connection>
    <ID>b18b628b-4bb1-4f2f-ba5d-b958459df85b</ID>
    <Persist>true</Persist>
    <Server>192.168.1.218</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA0F1+Zal3UU2QCjtLpTKPbwAAAAACAAAAAAAQZgAAAAEAACAAAADJVPQPSKCTtYN+5NaIs/aRyGrTcW6zJDKACLgkvUdPfAAAAAAOgAAAAAIAACAAAADDmowxuG2Ns3gY6K/un665cXQPfHY6Ervj82vgVmAANBAAAAB5FCZs5RtgUUY6hQGhSCYcQAAAAGMu1A4AVmh8xkBQy6vwlECfb8GQHfPGzlHBNTNu/N3LTahYW5eZnlZrjIGE3qUQSnzRjLV/GPC4BTTR7t+Vmqw=</Password>
    <Database>SiManage</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

---------非实名绑卡-------------
--
--环境：测试库
--1 使用这个接口可以根据用户名和社会保障号，成功获取该用户信息
ZSSB_CARDUSERINFO 

--2 使用这个接口 根据社保号 绑卡时，返回以下信息：
--3 该接口并没有校验短信验证码，任意输入都可以通过
Interface:ZWW_BIND 
Request:<RowSet><Row><AAC001>2000492575</AAC001><CAC202>osr_r0FgdC7T5S-sitAZAIyr3KYc</CAC202><CAE034>004</CAE034><CAE035 /><VerifyCode>sdf</VerifyCode></Row></RowSet>
Response:<?xml version="1.0" encoding="utf-8"?>
<ServiceResponse><RequestProcessed>FALSE</RequestProcessed><Message>#NOT_LISHUI#</Message><RequestID>-101</RequestID></ServiceResponse>
StatusCode:OK
ErrorCode:-101
ExceptionType:BadRequest



---------医保信息-------------
--
--环境：测试库
--获取医保信息 一直超时
Interface:ZSSB_MEDREC
Request:<RowSet><Row><AAC001>1000230356</AAC001><AAE030>20160101</AAE030><AAE031>20161231</AAE031></Row></RowSet><|@|><RowSet><Row><PAGESIZE>10</PAGESIZE><PAGEIDX>1</PAGEIDX></Row></RowSet>
Response:
StatusCode:
ErrorCode:
ExceptionType:BadStatus



---------社保证明-------------
--【已回复】
--环境：正式库
--获取社保证明  一直超时

Interface:DZPZ_CREATE
Request:<RowSet><Row><AAC001>1000230356</AAC001><CZE051>01</CZE051><CAE033>Govsvr</CAE033><CZE052 /><VerifyCode /><AAE030>201604</AAE030><AAE031>201704</AAE031></Row></RowSet>
Response:
StatusCode:
ErrorCode:
ExceptionType:BadStatus

---------查看亲情社保-------------
--【已回复】【已修正】
--环境：测试库
--查看用户亲情社保电子证明，发送的验证码，输入六个8无效
--回复：


---------个人参保-------------
--【已回复】【已修正】
--环境：正式环境
--提问时间：17-04-24 14:08
--回复时间：
--回复原因：综合系统调整程序的时候带来的问题
--个人参保有问题
Interface:GRYW_GTCB
Request:<RowSet><Row><AAC001>2001051599</AAC001><AAB301>331199</AAB301><AAZ042>005</AAZ042><AAE180>5000</AAE180><AAC040>5000</AAC040><CAE034>004</CAE034></Row></RowSet>
Response:<?xml version="1.0" encoding="utf-8"?>
<ServiceResponse><RequestProcessed>FALSE</RequestProcessed><Message>单位增员失败：ORA-01403: 未找到任何数据</Message><RequestID>0</RequestID></ServiceResponse>
StatusCode:OK
ErrorCode:0
ExceptionType:BadRequest