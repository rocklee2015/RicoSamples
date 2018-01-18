<Query Kind="SQL">
  <Connection>
    <ID>e03c4292-f666-430f-b731-9778e1db615d</ID>
    <Persist>true</Persist>
    <Server>192.168.1.218</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAtWYwgPY8nUqjDHfnsHWtWQAAAAACAAAAAAAQZgAAAAEAACAAAABuzYpujr/N23uaNOiRmny96yTwCRxNPAEkwaQCdorx6AAAAAAOgAAAAAIAACAAAAAO+C4xwXIDzfoiN5NR10uouGJRaGWc3xWqIFsjd/B7phAAAABmVQdWGbe9CaZyK20PxXZgQAAAABNn90YM371wavOkh0B/GylTgAKLPu88F8PRBDRoLqYsRBJwclXY8GiYDZ9Rt84DlPl3UUYvgi8hBf1iY+tLsb4=</Password>
    <Database>Cinema</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

--给我一个sql语句，能从你们数据库查询到这些项
--business_date：营业日期。                      no
--cinema_code：影院编码                          yes
--onlinesale_code:中间平台编码                   no
--screen_code：影厅编码。                        yes
--film_code：影片编码。                          yes
--session_code：场次编码。                       yes
--session_datetime：影片放映时间。               yes
--operation：操作，取值包括：
--•	1，售票
--•	2，退票
--•	3，预售
--•	4，补登
--code：电影票编码。                             yes   
--seat_code：座位编码。                          yes  会有多个
--price：票价。                                  yes  什么票价？售票单价还是总价？
--service：网络服务费用。                        yes
--online_sale：网络代售标识，取值包括：          yes  都是网络售票
--•	0，本地售票（忽略）
--•	1，网络代售
--datetime：操作时间。                           yes
--所有编码都要求来自售票系统的

SELECT '空' AS business_date,a.CinemaCode AS cinema_code , '空' AS onlinesale_code,b.HallCode AS screen_code,b.FilmCode AS film_code,b.MatcheCode AS session_code,b.ShowTime AS session_datetime,a.[Status] AS operation, d.FilmTicketCode AS code,d.SeatCode AS seat_code,b.Price AS price,b.ServiceAddFee AS [service],'1' AS online_sale,a.CreateTime AS [datetime]
FROM [order] a
LEFT JOIN FilmMatche b
    ON a.FilmMatcheId=b.Id
LEFT JOIN Cinema c
    ON a.CinemaId=c.Id
LEFT JOIN OrderTicket d
    ON a.Id=d.OrderId
WHERE a.Status=2