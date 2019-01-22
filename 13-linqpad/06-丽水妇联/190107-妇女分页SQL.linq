<Query Kind="SQL">
  <Connection>
    <ID>17e01685-dc05-4f58-b325-a01808c11ccd</ID>
    <Persist>true</Persist>
    <Server>192.168.1.234</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAPATbAiw07E6I+9qEhNm/EgAAAAACAAAAAAAQZgAAAAEAACAAAABzAlEA0VM7t75hP8GJK72tQX4rwUUS6OITSAfblo96owAAAAAOgAAAAAIAACAAAADZGJZSQ3htURHtHEZiuJuDaipkWU9gHaXlseCg2qugrhAAAADQBg+VPi+A6BEBkgw34q9/QAAAAKQrBk70oaBMFLbzFdT6UpbH+EPB23f4mlwbReUzsREO8d3Q/wpWHXFG9t1cLYHr3473FhsqJ+Fb1aHMJbQ5ug0=</Password>
    <Database>Wfsp.PreView</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>

SELECT  TOP
	20 *  
FROM
	(
	SELECT
		* ,
		ROW_NUMBER () OVER ( ORDER BY CreateTime DESC ) AS row_number 
	FROM
		(
		SELECT DISTINCT
			w.Id,
			e.Display AS EducationText,
			w.CardId,
			w.PoliticalStatus,
			w.Name,
            w.Nation,
			w.Async,
			w.AsyncTime,
			w.CreateTime,
			w.RealAddress,
			w.Birthday 
		FROM
			[Women] w
			LEFT JOIN [Honor] h ON w.Id = h.WomenId
			LEFT JOIN [BaseDataValue] b ON b.Id= h.HonorId 
			AND b.IsDeleted= 0
			LEFT JOIN [BaseDataValue] e ON e.Id= w.EducationId 
			AND e.IsDeleted= 0 
		WHERE
			w.IsDeleted= 0 
			 and CountyNum in (1416)  and ( CountyNum=1416)
		) t 
	) tt 
WHERE
	row_number > 0 
	
order by tt.CreateTime,tt.RealAddress	desc 