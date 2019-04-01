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

-- 6月26日 20180625XX1185000002925700W949 客户支付62 没有出票
update  [order] set 
Status=4,
PayCardNum='1185018062626899',
PayTime=CreateTime,
ThirdPay=CardTotal
where id='342acf09-4802-41ea-9dc7-6cf5e8310d71'

update  [order] set 
Status=4,
PayCardNum='1185018062626898',
PayTime=CreateTime,
ThirdPay=CardTotal
where id='7ef5a13d-34b4-4f37-9e59-6e7560b86174'