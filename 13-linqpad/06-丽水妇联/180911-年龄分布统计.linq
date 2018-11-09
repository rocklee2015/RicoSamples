<Query Kind="SQL">
  <Connection>
    <ID>528e09b9-d416-4159-8623-8cca7676ec17</ID>
    <Persist>true</Persist>
    <Server>192.168.1.218</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAALPitMYg51kiwFKmWIo6xOgAAAAACAAAAAAAQZgAAAAEAACAAAADD32sJmEhByxll7PeoNmOY5pihV+KZy1+QOBtAatmx8gAAAAAOgAAAAAIAACAAAABeV1bGUZZP87CJD/h7HALpb0OSx51ZUAnA7oa2W8F4ZBAAAACy03FBNWpUXZb7SbzsTLzbQAAAAJLIXhIzwE030yp+OGNfBv7k7rOjvtsLxZjUmorkpHNtUWSJpEvhkJpvvCVp03q2F4/eHPYTo5S5zaShl6k3M+Y=</Password>
    <Database>Wfsp.Test</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>


select a.name,count(0) as value from (

select 
	case when DATEDIFF(yy,Birthday,getdate())<20 then '0-20岁' 
         when (DATEDIFF(yy,Birthday,getdate())>=20 and DATEDIFF(yy,Birthday,getdate())<30) then '20-30岁'
		 when (DATEDIFF(yy,Birthday,getdate())>=30 and DATEDIFF(yy,Birthday,getdate())<40) then '30-40岁'
		 when (DATEDIFF(yy,Birthday,getdate())>=40 and DATEDIFF(yy,Birthday,getdate())<50) then '40-50岁'
		 when (DATEDIFF(yy,Birthday,getdate())>=50 and DATEDIFF(yy,Birthday,getdate())<60) then  '50-60岁'
		 when (DATEDIFF(yy,Birthday,getdate())>=60 and DATEDIFF(yy,Birthday,getdate())<70) then '60-70岁'
		 when DATEDIFF(yy,Birthday,getdate())>=70 then '70岁以上'
		 else '其它'
	end as name
from Women 
where RealAddress like '%丽水%'
) a

group by a.name 
order by a.name       

select '20岁以内' Name,sum(case when  DATEDIFF(yy,Birthday,getdate())<20 then 1 else 0 end) value from Women
union
select '20-30岁' Name,sum(case when (DATEDIFF(yy,Birthday,getdate())>=20 and DATEDIFF(yy,Birthday,getdate())<30) then 1 else 0 end) value from Women
union
select '30-40岁' Name,sum(case when (DATEDIFF(yy,Birthday,getdate())>=30 and DATEDIFF(yy,Birthday,getdate())<40) then 1 else 0 end) value from Women
union
select '40-50岁' Name,sum(case when (DATEDIFF(yy,Birthday,getdate())>=40 and DATEDIFF(yy,Birthday,getdate())<50) then 1 else 0 end) value from Women
union
select '50-60岁' Name,sum(case when (DATEDIFF(yy,Birthday,getdate())>=50 and DATEDIFF(yy,Birthday,getdate())<60) then 1 else 0 end) value from Women
union
select '60-70岁' Name,sum(case when (DATEDIFF(yy,Birthday,getdate())>=60 and DATEDIFF(yy,Birthday,getdate())<70) then 1 else 0 end) value from Women
union
select '70以上' Name,sum(case when DATEDIFF(yy,Birthday,getdate())>=70 then 1 else 0 end) value from Women