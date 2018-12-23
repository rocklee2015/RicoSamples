<Query Kind="SQL">
  <Connection>
    <ID>9b205a6a-1436-45c9-913d-1210b63f2ad9</ID>
    <Persist>true</Persist>
    <Server>192.168.1.218</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAPATbAiw07E6I+9qEhNm/EgAAAAACAAAAAAAQZgAAAAEAACAAAADAujZEVR5D8nZo9QbKf1UaQ2xjWZh7u6xlG4a1UKFmsgAAAAAOgAAAAAIAACAAAADkhhFYYd81hJnJPTU59CVoUNTwFc1vX3lR2gDuhoi8UhAAAABAzyNjS24zcqT6XiV7f/c4QAAAAM+p8E1Ob9YoF5Qo8fBz5+eR7vYP8ciuvj6IaGdN/YVM8UPS/9WveWXeQxIHLkgZwVJdr9ZpwRnfJE3uHkMNdtw=</Password>
    <Database>Wfsp.Test</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

update  Article set IsDeleted=1

update  Activities set IsDeleted=1


update  Aspirations set IsDeleted=1

update  QuestionAnswers set IsDeleted=1

update  Questionnaires set IsDeleted=1

update  QuestionOptions set IsDeleted=1


update Vote set IsDeleted=1

--update VoteInfo set IsDeleted=1

update SafeguardingRights set IsDeleted=1


delete from RoleAreas

delete from Organization