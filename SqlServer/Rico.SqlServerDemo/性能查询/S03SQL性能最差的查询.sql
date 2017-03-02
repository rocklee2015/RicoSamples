

SELECT TOP 100 (a.total_worker_time / a.execution_count) AS [Avg_CPU_Time] ,
           CONVERT (VARCHAR, Last_Execution_Time) AS [Last_Execution_Time] ,
                   Total_Physical_Reads ,
                   SUBSTRING(b.TEXT, a.statement_start_offset / 2, 
				   ( CASE
                          WHEN a.statement_end_offset = - 1 THEN len(convert(NVARCHAR(MAX), b.TEXT)) * 2
                          ELSE a.statement_end_offset
                      END - a.statement_start_offset ) / 2) AS [Query_Text] ,
                   dbname = Upper(db_name(b.dbid)) ,
                   b.objectid AS 'Object_ID',
                   B.*
FROM sys.dm_exec_query_stats a CROSS APPLY sys.dm_exec_SQL_text(a.SQL_handle) AS b
ORDER BY [Avg_CPU_Time] DESC