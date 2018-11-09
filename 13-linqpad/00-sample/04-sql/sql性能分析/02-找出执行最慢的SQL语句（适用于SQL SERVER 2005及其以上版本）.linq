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

SELECT top 20
	(total_elapsed_time / execution_count) / 1000 N'平均时间ms'
    ,total_elapsed_time / 1000 N'总花费时间ms'
    ,total_worker_time / 1000 N'所用的CPU总时间ms'
    ,total_physical_reads N'物理读取总次数'
    ,total_logical_reads / execution_count N'每次逻辑读次数'
    ,total_logical_reads N'逻辑读取总次数'
    ,total_logical_writes N'逻辑写入总次数'
    ,execution_count N'执行次数'
    ,SUBSTRING(st.text, (qs.statement_start_offset / 2) + 1
	, ((CASE statement_end_offset
    WHEN - 1 THEN DATALENGTH(st.text)
    ELSE qs.statement_end_offset END
	- qs.statement_start_offset) / 2) +1) N'执行语句'
    ,creation_time N'语句编译时间'
    ,last_execution_time N'上次执行时间'
    FROM
	sys.dm_exec_query_stats AS qs CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) st
WHERE
SUBSTRING(st.text, (qs.statement_start_offset / 2) + 1,
((CASE statement_end_offset
WHEN - 1 THEN DATALENGTH(st.text)
ELSE qs.statement_end_offset END
- qs.statement_start_offset) / 2) +1) not like '�tch%'
ORDER BY
total_elapsed_time / execution_count DESC;