<Query Kind="SQL">
  <Connection>
    <ID>8f35cbb5-7d32-4780-9466-d2ea7df6801a</ID>
    <Persist>true</Persist>
    <Server>192.168.1.218\mighost</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAABoybHsSXFUuz8AXaKmCqgAAAAAACAAAAAAAQZgAAAAEAACAAAAAY1L2xKXxTEwafKLsJIgRLp3lTtHAGIZJKfzP+Cm/fnQAAAAAOgAAAAAIAACAAAABFxQ3QIGCW+GW9ZwBRjYCQKjMVsx68ZWf41kU/8x/YExAAAADltx+Q8L+jR8smKtSA1KvTQAAAAAkFR+NNcSvAp0ax3jBbCKBrfQNaSCf3lR+Faqk/qDBA6Gqf9Zq2yxWWG/Dt5DcbvpxE6mq07V0vP7xoxwZR4r8=</Password>
    <Database>CinemaWdTest</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>



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