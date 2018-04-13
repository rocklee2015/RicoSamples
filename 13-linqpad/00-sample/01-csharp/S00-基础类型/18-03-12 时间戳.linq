<Query Kind="Program">
  <Connection>
    <ID>8f35cbb5-7d32-4780-9466-d2ea7df6801a</ID>
    <Persist>true</Persist>
    <Server>192.168.1.218\mighost</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAABoybHsSXFUuz8AXaKmCqgAAAAAACAAAAAAAQZgAAAAEAACAAAAAY1L2xKXxTEwafKLsJIgRLp3lTtHAGIZJKfzP+Cm/fnQAAAAAOgAAAAAIAACAAAABFxQ3QIGCW+GW9ZwBRjYCQKjMVsx68ZWf41kU/8x/YExAAAADltx+Q8L+jR8smKtSA1KvTQAAAAAkFR+NNcSvAp0ax3jBbCKBrfQNaSCf3lR+Faqk/qDBA6Gqf9Zq2yxWWG/Dt5DcbvpxE6mq07V0vP7xoxwZR4r8=</Password>
    <Database>BloodDonation</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	var time = GetTimeFromStamp(1523342084);
	time.Dump();
}

void GetTimeStamp()
{
	System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区

	long timeStamp = (long)(DateTime.Now - startTime).TotalSeconds; // 相差秒数
	timeStamp.Dump("精确到秒");
	timeStamp.ToString().Length.Dump("位数");

	timeStamp = (long)(DateTime.Now - startTime).TotalMilliseconds; // 相差毫秒数

	timeStamp.Dump("精确到毫秒");
	timeStamp.ToString().Length.Dump("位数");
}
DateTime GetTimeFromStamp(long timeLong)
{
	DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
	return dtStart.AddSeconds(timeLong);
}
// Define other methods and classes here