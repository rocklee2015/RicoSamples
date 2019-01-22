<Query Kind="SQL" />

select top 10 County,CountyNum,City,CityNum,Town,TownNum from Women

update women set County='松阳县',CountyNum=1416 where RealAddress like '%松阳县%'
update women set County='云和县',CountyNum=1836  where RealAddress like '%云和县%'
update women set County='景宁畲族自治县',CountyNum=2373  where RealAddress like '%景宁畲族自治县%'
update women set County='庆元县',CountyNum=2021  where RealAddress like '%庆元县%'
update women set County='遂昌县',CountyNum=1166  where RealAddress like '%遂昌县%'
update women set County='龙泉市',CountyNum=2658  where RealAddress like '%龙泉市%'
update women set County='莲都区',CountyNum=2  where RealAddress like '%莲都区%'
update women set County='青田县',CountyNum=411  where RealAddress like '%青田县%'
update women set County='缙云县',CountyNum=888  where RealAddress like '%缙云县%'


update women set City='丽水市',CityNum=1

update women set TownNum=0

update women set iscalc=0

update Women set  TownNum=1849 where id='e995c25a-db62-4b31-bd83-2d842de44b19'

delete from Women

delete from Honor

select City,CityNum,County,CountyNum,Town TownNum,Village,VillageNum,Name,RealAddress,PermanentAddress from  Women 
where id='e6a3d89b-7ef9-45d3-836a-71989408c9fd'

select top 50 City,CityNum,County,CountyNum,Town, TownNum,Village,VillageNum,Name,PermanentAddress,Birthday from Women 

where (Name='杨久远' or Name='杨凯') and IsDeleted=0


select GAMaritalStatus from Women 

GROUP BY GAMaritalStatus

select top 50 MaritalStatus,Nation,EducationId,GraduateEducationId,GANation,GACountry,GABirthday,GAMembership,GAMaritalStatus  from Women 
where GAMaritalStatus is not null

SELECT count(0) from Women

SELECT * from WomenMapPeoples

--DELETE from WomenMapPeoples

--delete from MapRegional

--select IdNum,Name,* from MapRegional where  Sectiontype like '二%'
--select IdNum,Name,FullName,* from MapRegional where  Sectiontype like '三%'
select IdNum,Name,FullName,* from MapRegional where  Sectiontype like '四%'
select IdNum,Name,FullName,* from MapRegional where  Sectiontype like '五%'
select IdNum,Name,FullName,* from MapRegional where IdNum=2685

select IdNum,Name,FullName,* from MapRegional where IdNum=2658
select IdNum,Name,* from MapRegional where  IdNum=1849

select IdNum,Name,* from MapRegional where  IdNum=1862

select * from BaseDataValue where BaseDataType=1 and Display in ('国家级先进个人') 


SELECT * from Honor

SELECT
	a.[Value] as name,
	COUNT ( b.WomenId ) as count
FROM
	BaseDataValue a
	
	LEFT JOIN Honor b ON a.Id= b.HonorId 
	LEFT JOIN Women c ON b.WomenId=c.id
WHERE
	a.BaseDataType= 1 
	AND a.IsDeleted= 0  and c.IsDeleted=0 and c.CountyNum=110

GROUP BY
	a.[Value]

SELECT * from WomenFederationMembers

select * from Admin

select * from RoleAreas where roleid='39d826e9-72e5-4b30-923e-fe3270929279'
