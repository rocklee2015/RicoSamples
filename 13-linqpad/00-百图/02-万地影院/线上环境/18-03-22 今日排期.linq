<Query Kind="Statements">
  <Connection>
    <ID>edb569e0-1029-4670-bd56-f4981986d255</ID>
    <Persist>true</Persist>
    <Server>101.132.69.71</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAABoybHsSXFUuz8AXaKmCqgAAAAAACAAAAAAAQZgAAAAEAACAAAADlMDTg8rh8stUlZgjvxKWfJkLaoJu5GrJnhua9EICUhQAAAAAOgAAAAAIAACAAAAB7x+0HnQ6b0YgF1diupbyFoqj8o5uo5sGeSJrsiKJKHBAAAABM8IUq4NDIt9vX4B4yLwcyQAAAAJFB1V+gp2sgHISifMpmzqEsGAOnWOnhx7O3RcsGhbmZYn41eVGBCO7ch97kncwveJgTFqk5lA+bm4awvliGAl0=</Password>
    <Database>CinemaWd</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>


var time=DateTime.Now; //今天
time=time.AddDays(1);//明天

FilmSchedules
.Where(a=>
a.ShowDateTime> time.Date
&&a.ShowDateTime<=time.AddDays(1).Date
//&&a.ScheduleId.Contains("58671052")
//&&a.FilmName.Contains("太平洋")
)
.OrderByDescending(a=>a.CreateTime)
.Select(a => new{
a.FilmName,
a.CreateTime,
a.ScheduleId,
a.ScheduleKey,
a.StandardPrice,
a.LowestPrice,
a.SettlePrice,
a.TicketFee,
a.ShowDateTime,
a.IsDeleted,
}).Dump();

//D04DE356B8F1F6DE43973253CBDFC949
