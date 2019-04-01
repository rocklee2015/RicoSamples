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

-- 6月30日 用户13735969959，购票四张，9排04座,9排05座,9排06座,9排07座，取票号2018063033804649
--支付宝支付的钱已退还
update  [order] set 
PayType=1,
PayCardNum='1185200030795',

ThirdPay=CardTotal
where id='66738075-8f9f-4781-9bdc-5164eef2ef03'

