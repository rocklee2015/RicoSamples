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
	var str = "abcdefg.百图科技";
	//Encoding.Default.Dump("默认编码");
	Encoding.Default.GetBytes(str).Length.Dump("GB2312 字节 长度");
	Encoding.UTF8.GetBytes(str).Length.Dump("UTF8 字节长度（UTF8一个汉字占3个字节）");
	Encoding.Unicode.GetBytes(str).Length.Dump("Unicode 字节长度");
	Encoding.ASCII.GetBytes(str).Length.Dump("ASCII 字节长度");
	str.Length.Dump("字符长度");

	
}

// Define other methods and classes here
