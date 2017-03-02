
SELECT top 100 (total_logical_reads/execution_count) AS [ƽ���߼���ȡ����],
           (total_logical_writes/execution_count) AS [ƽ���߼�д�����],
           (total_physical_reads/execution_count) AS [ƽ�������ȡ����],
           Execution_count ���д���, substring(qt.text,r.statement_start_offset/2+1, 
		   (CASE
                 WHEN r.statement_end_offset = -1 THEN datalength(qt.text)
                 ELSE r.statement_end_offset
            END - r.statement_start_offset)/2+1) [�����﷨],
           getdate() [��ѯʱ��]
FROM sys.dm_exec_query_stats AS r CROSS apply sys.dm_exec_sql_text(r.sql_handle) AS qt
ORDER BY --[��ѯʱ��] desc
 (total_logical_reads + total_logical_writes) DESC