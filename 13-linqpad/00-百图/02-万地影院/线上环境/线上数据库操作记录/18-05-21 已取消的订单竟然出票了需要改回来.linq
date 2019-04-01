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

--用户手机：	15215783585
--昵称：从回自我
--会员卡：
--商户号：20180414XX1185000009078600W140

select bookingid,cardtotal,thirdpay,paycardnum,paytime,status,createtime from [order]  where id ='aeb42960-0498-4b6a-b660-ff418dba2d69'
--update [order]  
--set 
--bookingid='118501804147067',
--status=2,
--thirdpay=72,
--paycardnum='1185200011754',
--paytime='2018-04-14 16:34:18'
--
--
--where id ='aeb42960-0498-4b6a-b660-ff418dba2d69'