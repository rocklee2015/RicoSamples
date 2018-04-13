<Query Kind="SQL" />

--1.删除第40-50行之间的数据；
with tabs as
(
 select ROW_NUMBER() over(order by id) as rows ,* from t_class
)
delete tabs where tabs.rows between 40 and 50

2） delete from t_class where id in (
select id from (
select ROW_NUMBER() over(order by id) as rows ,id from t_class)t1
where rows between 40 and 50
)