<Query Kind="SQL">
  <Connection>
    <ID>8f35cbb5-7d32-4780-9466-d2ea7df6801a</ID>
    <Persist>true</Persist>
    <Server>192.168.1.218\mighost</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAABoybHsSXFUuz8AXaKmCqgAAAAAACAAAAAAAQZgAAAAEAACAAAAAY1L2xKXxTEwafKLsJIgRLp3lTtHAGIZJKfzP+Cm/fnQAAAAAOgAAAAAIAACAAAABFxQ3QIGCW+GW9ZwBRjYCQKjMVsx68ZWf41kU/8x/YExAAAADltx+Q8L+jR8smKtSA1KvTQAAAAAkFR+NNcSvAp0ax3jBbCKBrfQNaSCf3lR+Faqk/qDBA6Gqf9Zq2yxWWG/Dt5DcbvpxE6mq07V0vP7xoxwZR4r8=</Password>
    <Database>SocialInsurance</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

--查看数据库索引的使用情况
select db_name(database_id) as N'TOPK_TO_DEV',  --库名
        object_name(a.object_id) as N'TopProjectNew',  --表明
        b.name N'索引名称',
        user_seeks N'用户索引查找次数',
        user_scans N'用户索引扫描次数',
        last_user_seek N'最后查找时间',
       last_user_scan N'最后扫描时间',
        rows as N'表中的行数'
from sys.dm_db_index_usage_stats a join
	  sys.indexes b
      on a.index_id = b.index_id
     and a.object_id = b.object_id
     join sysindexes c
	  on c.id = b.object_id
where database_id = db_id('TOPK_TO_DEV')-- - 改成要查看的数据库
 and object_name(a.object_id) not like 'sys%'
 order by user_seeks,user_scans,object_name(a.object_id)
 
 
 --清空查询缓存
 DBCC freeproccache
 
 
-- 查看sql执行计划
SELECT  *
 FROM   TopProjectNew  --表名
 
SELECT  cacheobjtype ,
        objtype ,
       usecounts ,
        sql
FROM    sys.syscacheobjects
WHERE   sql NOT LIKE '%cach%'
        AND sql NOT LIKE '"sys."'
       AND cacheobjtype LIKE '%Plan%'