<Query Kind="SQL">
  <Connection>
    <ID>4570b9c7-5775-4e6e-b1c8-58418e563da0</ID>
    <Persist>true</Persist>
    <Server>192.168.1.218\Mighost</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA5Mi0+DWzikKMz609cg87DgAAAAACAAAAAAAQZgAAAAEAACAAAAA26jlr7U78ZmrKy159SCTLbkXOr9RENDmNd4S0xYb4xgAAAAAOgAAAAAIAACAAAAB+zF3wADdFeSWFK3ri8s/P1pJ3MeYhstl2wb+iOoes+hAAAABeXeHUBN+erJiGbHW94FCRQAAAABPnJUQvD29O8X4L/Frldvj6mQymZoiZXQ3yfGQRS9pIIT6vFpKzc31NgabaSGzKiJ+fqLnUHorqaF5nIyTOuII=</Password>
    <Database>InsuranceUser</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

/**
 * 2017-04-04 删除微信的账号绑定
 */
use InsuranceUser

select * from [User] where openid='osr_r0OuF9eWH6lIDUNZOvta5YsY'
select * from [UserApp] where openid='osr_r0OuF9eWH6lIDUNZOvta5YsY'

select * from [UserShipChangeRecord] where OpenId='osr_r0FgdC7T5S-sitAZAIyr3KYc'


/**
 * 2017-04-04 删除微信的账号绑定
 */
select * from [User] where openid='osr_r0FgdC7T5S-sitAZAIyr3KYc'

delete from [User] where Id in(
select Id from [User] where OpenId in('osr_r0FgdC7T5S-sitAZAIyr3KYc','ooS4L0QCIvxi_OceSGF6q8jFJj-c') )

/**
 * 2017-04-04 删除小程序平台的绑定号
 */
 
 delete from [User] where openid in('osr_r0FgdC7T5S-sitAZAIyr3KYc')
 delete from [UserApp] where openid in('osr_r0FgdC7T5S-sitAZAIyr3KYc')
 
 delete from [User] where siuserid='2000850322'
 
select * from [User] where platform =3 and id='0a6a341b-0301-4bc5-9be4-ead7f0a7b454'

select * from [UserApp] where userid='0a6a341b-0301-4bc5-9be4-ead7f0a7b454'

delete from [User] where Id in(
select id from [User] where platform =3 )

delete from [User] where Id in('835b6cea-acd2-4e5d-b3c2-8994b91ba18d')

update  [User] set siuserid='1000017878'    where id='575a7a2c-6025-4cf6-a93b-94a6e511a021'

select * from [User] where Platform=3

--delete from [User] where Platform=3 and SiUserId='2000850322'

update  [User] set siuserid='2000850322'    where id='b0107f94-eca9-42bf-b1a7-89fb7e7b4660'

/**
 * 2017-07-28 更换账号
 */
--李林社保-> 将陈洋 换成李宽
declare @userId nvarchar(50)
set @userId='9209d9e7-11bf-4fcd-85da-0d5a4446871d'
declare @openid nvarchar(50)
set @openid='osr_r0FgdC7T5S-sitAZAIyr3KYc'

update [User] set OpenId=@openid where id= @userId
update  [UserApp]  set OpenId=@openid where userid=@userId

--李林社保-> 将李宽 换成陈洋
declare @userId nvarchar(50)
set @userId='9209d9e7-11bf-4fcd-85da-0d5a4446871d'
declare @openid nvarchar(50)
set @openid='osr_r0OuF9eWH6lIDUNZOvta5YsY'

update [User] set OpenId=@openid where id= @userId
update  [UserApp]  set OpenId=@openid where userid=@userId


update  [User] set siuserid='2000850322'    where id='2f0ed0d4-51f4-4ef3-828f-e89c9ae88bea'

update  [User] set OpenId='osr_r0FgdC7T5S-sitAZAIyr3KYc'    where id='2f0ed0d4-51f4-4ef3-828f-e89c9ae88bea'
/*
insert into [User](id,openid,platform,userplatformid,siuserid,isdeleted,createtime,deletetime,coordinatecode,userauditstate)

select newid() as id,openid,platform,userplatformid,siuserid,isdeleted,createtime,deletetime,coordinatecode,userauditstate from [User] where id='1e394e8b-ee28-4cb2-b13f-dea49b1c6d88'
*/
-- 【杭州百图】 AppId
--陈洋 osr_r0OuF9eWH6lIDUNZOvta5YsY
--李宽 osr_r0FgdC7T5S-sitAZAIyr3KYc
--胡   osr_r0FTMUMEPIHWcDdwLBuw2kwg
--鲍广义 osr_r0EywQJi2psmI66UI0msSnqY
--杨芳   osr_r0HigWx3Gv9ljo_ctGuY9cEQ
--- 【ThirdSchool】 AppId 
--李宽 ooS4L0QCIvxi_OceSGF6q8jFJj-c
--陈洋 ooS4L0bV15aPXmy0fqCqzfEyBcmM
--鲍广 ooS4L0Up-oZv_wlOvDGmXGPNyTTo
--胡   ooS4L0bGSEV_s7vyZRdi1AmAClnw

--insert into [User](Id,openid,[platform],SiUserId,CreateTime,CoordinateCode)values
--(newid(),
--'',--OpendId
--3,
--'',--SiUserId
--GETDATE(),
--'331102',
--1
--)