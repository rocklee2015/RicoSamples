<Query Kind="SQL">
  <Connection>
    <ID>4570b9c7-5775-4e6e-b1c8-58418e563da0</ID>
    <Persist>true</Persist>
    <Server>192.168.1.218\Mighost</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA5Mi0+DWzikKMz609cg87DgAAAAACAAAAAAAQZgAAAAEAACAAAAA26jlr7U78ZmrKy159SCTLbkXOr9RENDmNd4S0xYb4xgAAAAAOgAAAAAIAACAAAAB+zF3wADdFeSWFK3ri8s/P1pJ3MeYhstl2wb+iOoes+hAAAABeXeHUBN+erJiGbHW94FCRQAAAABPnJUQvD29O8X4L/Frldvj6mQymZoiZXQ3yfGQRS9pIIT6vFpKzc31NgabaSGzKiJ+fqLnUHorqaF5nIyTOuII=</Password>
    <Database>CinemaWdTest</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Id]
      ,[FilmId]
      ,[UserId]
      ,[IsDeleted]
      ,[CreateTime]
      ,[DeleteTime]
  FROM [CinemaWdTest].[dbo].[FilmCollect] where UserId='5CFF281F-AF1B-42B0-BCA9-EBAC2DB3B57E'


  select b.FilmName,b.Status,a.* from FilmCollect as a 
  inner join Film b on a.FilmId=b.Id
  where a.UserId='5CFF281F-AF1B-42B0-BCA9-EBAC2DB3B57E'

  select * from CinemaHall where id='218D69DE-8D79-4245-9BF9-7E9CAEB4B895'

  select * from [CinemaHallSeat] where HallId='218D69DE-8D79-4245-9BF9-7E9CAEB4B895' order by SeatCode

  select * from FilmMatche where DATEDIFF(dd,ShowTime,GETDATE())=0 and HallId='218D69DE-8D79-4245-9BF9-7E9CAEB4B895'

  select * from FilmMatche where MatcheCode ='66839535'