---dm_exec_query_stats msdn 视图查看
--https://msdn.microsoft.com/zh-cn/library/ms189741(v=sql.110).aspx
-- 执行时间单位：微秒(μs)

SELECT TOP 1000 
--创建时间 
QS.creation_time, 
--查询语句 
SUBSTRING(ST.text,(QS.statement_start_offset/2)+1, 
((CASE QS.statement_end_offset WHEN -1 THEN DATALENGTH(st.text) 
ELSE QS.statement_end_offset END - QS.statement_start_offset)/2) + 1 
) AS statement_text, 
--执行文本 
ST.text, 
--执行计划 
QS.total_worker_time, 
QS.last_worker_time, 
QS.max_worker_time, 
QS.min_worker_time 
FROM 
sys.dm_exec_query_stats QS 
--关键字 
CROSS APPLY 
sys.dm_exec_sql_text(QS.sql_handle) ST 
WHERE 
QS.creation_time BETWEEN '2012-12-03 09:00:00' AND GETDATE()
-- AND ST.text LIKE '%%' 
ORDER BY 
QS.creation_time DESC