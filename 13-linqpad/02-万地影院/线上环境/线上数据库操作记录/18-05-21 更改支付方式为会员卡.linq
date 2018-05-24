<Query Kind="SQL">
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
</Query>


select id,paytype,total,cardtotal,thirdpay from [order] where id in(
'2a774530-c250-49ec-8b7f-138c5a616d1f',
'8d0c418b-c4df-49fa-a794-8eeaf96f8593',
'28da3b14-3fae-4a59-b4d0-52d6bd79de96',
'99435323-f5f9-4674-be45-51bfef902c20'
)
--2a774530-c250-49ec-8b7f-138c5a616d1f 0 
--99435323-f5f9-4674-be45-51bfef902c20 0 
--28da3b14-3fae-4a59-b4d0-52d6bd79de96 0 
--8d0c418b-c4df-49fa-a794-8eeaf96f8593 2 

--
--update [order] set paytype=1 where id in(
--'2a774530-c250-49ec-8b7f-138c5a616d1f',
--'8d0c418b-c4df-49fa-a794-8eeaf96f8593',
--'28da3b14-3fae-4a59-b4d0-52d6bd79de96',
--'99435323-f5f9-4674-be45-51bfef902c20'
--)