<Query Kind="SQL">
  <Connection>
    <ID>528e09b9-d416-4159-8623-8cca7676ec17</ID>
    <Persist>true</Persist>
    <Server>192.168.1.218</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAALPitMYg51kiwFKmWIo6xOgAAAAACAAAAAAAQZgAAAAEAACAAAADD32sJmEhByxll7PeoNmOY5pihV+KZy1+QOBtAatmx8gAAAAAOgAAAAAIAACAAAABeV1bGUZZP87CJD/h7HALpb0OSx51ZUAnA7oa2W8F4ZBAAAACy03FBNWpUXZb7SbzsTLzbQAAAAJLIXhIzwE030yp+OGNfBv7k7rOjvtsLxZjUmorkpHNtUWSJpEvhkJpvvCVp03q2F4/eHPYTo5S5zaShl6k3M+Y=</Password>
    <Database>Wfsp.Test</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>



declare @ids nvarchar(max)
set @ids='('
--select @ids=@ids+''''+ cast(id as varchar(max))+''''+','+  from admin 
select @ids=@ids+''''+cast(wid as varchar(10))+''''+',' from women 
set @ids=@ids+')'
set @ids=left(@ids,len(@ids)-1)
print @ids

select * from women where wid !=null