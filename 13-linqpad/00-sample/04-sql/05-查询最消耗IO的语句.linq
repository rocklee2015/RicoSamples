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