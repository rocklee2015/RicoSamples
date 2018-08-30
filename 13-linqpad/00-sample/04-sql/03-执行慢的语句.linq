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

--执行最慢的SQL语句
 
SELECT
 
(total_elapsed_time / execution_count)/1000 N'平均时间ms'
 
,total_elapsed_time/1000 N'总花费时间ms'
 
,total_worker_time/1000 N'所用的CPU总时间ms'
 
,total_physical_reads N'物理读取总次数'
 
,total_logical_reads/execution_count N'每次逻辑读次数'
 
,total_logical_reads N'逻辑读取总次数'
 
,total_logical_writes N'逻辑写入总次数'
 
,execution_count N'执行次数'
 
,SUBSTRING(st.text, (qs.statement_start_offset/2) + 1,
 
((CASE statement_end_offset
 
WHEN -1 THEN DATALENGTH(st.text)
 
ELSE qs.statement_end_offset END
 
- qs.statement_start_offset)/2) + 1) N'执行语句'
 
,creation_time N'语句编译时间'
 
,last_execution_time N'上次执行时间'
 
FROM
 
sys.dm_exec_query_stats AS qs CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) st
 
WHERE
 
SUBSTRING(st.text, (qs.statement_start_offset/2) + 1,
 
((CASE statement_end_offset
 
WHEN -1 THEN DATALENGTH(st.text)
 
ELSE qs.statement_end_offset END
 
- qs.statement_start_offset)/2) + 1) not like 'tch%'
 
ORDER BY
 
total_elapsed_time / execution_count DESC;
