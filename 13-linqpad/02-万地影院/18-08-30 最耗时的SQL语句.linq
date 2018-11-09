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

--http://blog.itpub.net/29371470/viewspace-2130906/
-- 优化前
declare @d datetime
set @d = getdate()

SELECT Id,
        LockOrderId,
        CinemaLinkId,
        PayTime,
        PayType
FROM [Order]
WHERE IsDeleted=0
        AND PayTime is null
        AND [Status]=0
        AND DATEDIFF(SECOND,ExpireTime,GETDATE())>1 
		
select [语句执行花费时间(毫秒)]=datediff(ms,@d,getdate()) 
go
-- 优化后
declare @d datetime
set @d = getdate()
		SELECT Id,
        LockOrderId,
        CinemaLinkId,
        PayTime,
        PayType
FROM [Order]
WHERE IsDeleted=0
        AND PayTime is null
        AND [Status]=0
		AND ExpireTime >  getdate()
	
select [语句执行花费时间(毫秒)]=datediff(ms,@d,getdate()) 
go
       