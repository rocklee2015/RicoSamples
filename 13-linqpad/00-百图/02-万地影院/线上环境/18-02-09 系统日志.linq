<Query Kind="Expression">
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

AdoLogs
.Where(a=>a.CreateTime>DateTime.Parse("2018-06-30 18:37:00"))
.Where(a=>a.CreateTime<DateTime.Parse("2018-06-30 18:40:00"))
.OrderByDescending(a=>a.CreateTime)
//.OrderBy(a=>a.CreateTime)

//.Where(a=>a.)
.Take(200).ToList()
.Select(a => new {
a.Path,
创建时间=a.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
a.Level,
a.Message,
a.Data,
a.Detail
})