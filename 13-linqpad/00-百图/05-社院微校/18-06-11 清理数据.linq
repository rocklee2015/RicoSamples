<Query Kind="SQL">
  <Connection>
    <ID>8f35cbb5-7d32-4780-9466-d2ea7df6801a</ID>
    <Persist>true</Persist>
    <Server>192.168.1.218\mighost</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAABoybHsSXFUuz8AXaKmCqgAAAAAACAAAAAAAQZgAAAAEAACAAAAAY1L2xKXxTEwafKLsJIgRLp3lTtHAGIZJKfzP+Cm/fnQAAAAAOgAAAAAIAACAAAABFxQ3QIGCW+GW9ZwBRjYCQKjMVsx68ZWf41kU/8x/YExAAAADltx+Q8L+jR8smKtSA1KvTQAAAAAkFR+NNcSvAp0ax3jBbCKBrfQNaSCf3lR+Faqk/qDBA6Gqf9Zq2yxWWG/Dt5DcbvpxE6mq07V0vP7xoxwZR4r8=</Password>
    <Database>WeixiaoCosClound</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

delete from AdminRole
delete from Admin
delete from ClassInfo
delete from [Group]
delete from IdentityPassword
delete from IdentityUserLoginInfo
delete from IdentityUser
delete from Menu
delete from RoleMenu
delete from Role
delete from StudentMapping
--delete from Student
delete from TaskInfo
delete from Teacher

delete from Student