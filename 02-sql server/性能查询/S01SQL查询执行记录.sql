---dm_exec_query_stats msdn ��ͼ�鿴
--https://msdn.microsoft.com/zh-cn/library/ms189741(v=sql.110).aspx
-- ִ��ʱ�䵥λ��΢��(��s)

SELECT TOP 1000 
--����ʱ�� 
QS.creation_time, 
--��ѯ��� 
SUBSTRING(ST.text,(QS.statement_start_offset/2)+1, 
((CASE QS.statement_end_offset WHEN -1 THEN DATALENGTH(st.text) 
ELSE QS.statement_end_offset END - QS.statement_start_offset)/2) + 1 
) AS statement_text, 
--ִ���ı� 
ST.text, 
--ִ�мƻ� 
QS.total_worker_time, 
QS.last_worker_time, 
QS.max_worker_time, 
QS.min_worker_time 
FROM 
sys.dm_exec_query_stats QS 
--�ؼ��� 
CROSS APPLY 
sys.dm_exec_sql_text(QS.sql_handle) ST 
WHERE 
QS.creation_time BETWEEN '2012-12-03 09:00:00' AND GETDATE()
-- AND ST.text LIKE '%%' 
ORDER BY 
QS.creation_time DESC