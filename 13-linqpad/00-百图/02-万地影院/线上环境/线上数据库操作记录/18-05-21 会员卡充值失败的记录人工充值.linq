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
  <Output>DataGrids</Output>
</Query>


select * from [leaguerrecharge] where id in(
'cbf41367-1e99-4688-b981-512ca0983b26',
'46f6d345-ec21-450e-a522-e2fd153e2dbb',
'1dd34c7c-7b11-4bd4-9ef5-505ef597b3b6',
'6f4b9872-ade0-4f75-8d37-ba7c030d1cdc'
)

--update [leaguerrecharge] set RechargeStatus=2,Description='2018-05-21 14:06:26 13305885108 尝试充值失败！ 支付宝实收300.00, 人工充值300元' where id='1dd34c7c-7b11-4bd4-9ef5-505ef597b3b6'
--update [leaguerrecharge] set RechargeStatus=2,Description='2018-05-21 14:06:02 15857886388 尝试充值失败！ 支付宝实收16.00, 人工充值16元'  where id='cbf41367-1e99-4688-b981-512ca0983b26'
--update [leaguerrecharge] set RechargeStatus=2,Description='2018-05-21 14:06:33 13587175289 尝试充值失败！ 支付宝实收200.00, 人工充值200元'  where id='6f4b9872-ade0-4f75-8d37-ba7c030d1cdc'
--update [leaguerrecharge] set RechargeStatus=2,Description='2018-05-21 14:06:14 18157895670 尝试充值失败！ 微信实收10.00, 人工充值10元'  where id='46f6d345-ec21-450e-a522-e2fd153e2dbb'
--