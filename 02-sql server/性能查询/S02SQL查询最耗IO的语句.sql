
SELECT top 100 (total_logical_reads/execution_count) AS [平均逻辑读取次数],
           (total_logical_writes/execution_count) AS [平均逻辑写入次数],
           (total_physical_reads/execution_count) AS [平均对象读取次数],
           Execution_count 运行次数, substring(qt.text,r.statement_start_offset/2+1, 
		   (CASE
                 WHEN r.statement_end_offset = -1 THEN datalength(qt.text)
                 ELSE r.statement_end_offset
            END - r.statement_start_offset)/2+1) [运行语法],
           getdate() [查询时间]
FROM sys.dm_exec_query_stats AS r CROSS apply sys.dm_exec_sql_text(r.sql_handle) AS qt
ORDER BY --[查询时间] desc
 (total_logical_reads + total_logical_writes) DESC