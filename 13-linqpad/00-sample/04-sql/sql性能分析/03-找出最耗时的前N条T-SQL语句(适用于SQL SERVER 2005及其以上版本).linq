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
  <Output>DataGrids</Output>
</Query>

--给N赋初值为30
declare @n int set @n = 30

; with maco as
(
	select top(@n)
        plan_handle,  
        sum(total_worker_time) as total_worker_time ,  
        sum(execution_count) as execution_count ,  
        count(1) as sql_count
    from sys.dm_exec_query_stats group by plan_handle
    order by sum(total_worker_time) desc
)  
select t.text ,
		a.total_worker_time ,
		a.execution_count ,
		a.sql_count
from    maco a
        cross apply sys.dm_exec_sql_text(plan_handle) t

/* 结果格式如下  
text     total_worker_time  execution_count   sql_count  
-------- ------------------ ----------------- ---------  
内容略  
*/
  