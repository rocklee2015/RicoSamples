<Query Kind="SQL">
  <Connection>
    <ID>edb569e0-1029-4670-bd56-f4981986d255</ID>
    <Persist>true</Persist>
    <Server>101.132.69.71</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAABoybHsSXFUuz8AXaKmCqgAAAAAACAAAAAAAQZgAAAAEAACAAAADlMDTg8rh8stUlZgjvxKWfJkLaoJu5GrJnhua9EICUhQAAAAAOgAAAAAIAACAAAAB7x+0HnQ6b0YgF1diupbyFoqj8o5uo5sGeSJrsiKJKHBAAAABM8IUq4NDIt9vX4B4yLwcyQAAAAJFB1V+gp2sgHISifMpmzqEsGAOnWOnhx7O3RcsGhbmZYn41eVGBCO7ch97kncwveJgTFqk5lA+bm4awvliGAl0=</Password>
    <Database>CinemaWd</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

--查询会员卡绑定多条的记录
--225-101=124 删除多余124条记录

select cardno,count(cardno) from Leaguer 
where isdeleted=0 
group by cardno having count(*)>1

select * from  Leaguer 
where 
isdeleted=0 and
cardno in(
	select cardno from Leaguer 
	where isdeleted=0 
	group by cardno having count(*)>1) 
and
createtime not in(
	select min(createtime) from Leaguer 
	where isdeleted=0 
	group by cardno having count(*)>1
)

--过期的卡
select cardno,count(cardno) from Leaguer 
where status=5 and isdeleted=0
group by cardno having count(*)>1

--过期的卡有没有充值的
select * from LeaguerRecharge 
where cardno in 
(
select cardno from Leaguer 
where status=5 and isdeleted=0
group by cardno having count(*)>1
)




