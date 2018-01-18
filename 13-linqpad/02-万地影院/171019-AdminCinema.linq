<Query Kind="Program">
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

void Main()
{
	var query = from admin in Admins
				join adminCinema in AdminCinemas on admin.Id equals adminCinema.AdminId
				join cinema in Cinemas on adminCinema.CinemaId equals cinema.Id
				where admin.AdminName.Contains("admin") && cinema.CinemaName.Contains("888")
				select new {
				  admin.AdminName,
				  cinema.CinemaName
				};
	query.ToList().Dump();
}

// Define other methods and classes here
