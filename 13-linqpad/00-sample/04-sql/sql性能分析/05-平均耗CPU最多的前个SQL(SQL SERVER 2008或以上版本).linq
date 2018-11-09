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

SELECT TOP 20
    total_worker_time/1000 AS [总消耗CPU 时间(ms)],execution_count [运行次数],
    qs.total_worker_time/qs.execution_count/1000 AS [平均消耗CPU 时间(ms)],
    last_execution_time AS [最后一次执行时间],min_worker_time /1000 AS [最小执行时间(ms)],
    max_worker_time /1000 AS [最大执行时间(ms)],
    SUBSTRING(qt.text,qs.statement_start_offset/2+1, 
        (CASE WHEN qs.statement_end_offset = -1 
        THEN DATALENGTH(qt.text) 
        ELSE qs.statement_end_offset END -qs.statement_start_offset)/2 + 1) 
    AS [使用CPU的语法], qt.text [完整语法],
    qt.dbid, dbname=db_name(qt.dbid),
    qt.objectid,object_name(qt.objectid,qt.dbid) ObjectName
FROM sys.dm_exec_query_stats qs WITH(nolock)
CROSS apply sys.dm_exec_sql_text(qs.sql_handle) AS qt
WHERE  execution_count>1
ORDER BY (qs.total_worker_time/qs.execution_count/1000) DESC