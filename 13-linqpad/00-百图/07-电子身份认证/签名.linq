<Query Kind="Program">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var appId = "0000180809172057";
	var appSercret = "f20813526675728bb8f708b50c829230";
	//var url = "/facein/useridcard";
	var url = "/FaceIn/GetFaceResult";
	var timeStamp = DateTime.Now.ToUnixTime() / 1000;

	timeStamp.Dump("时间戳");
	var plainText = $"{appId}&{url.ToLower()}&{timeStamp}";
	ToBase64hmac(plainText, appSercret).Dump("默认的签名");
	var pText = Encoding.UTF8.GetBytes(plainText);
	Convert.ToBase64String(pText).Dump();
	//签名结果
	HMACSHA1Sign(appId, appSercret, url, timeStamp).Dump("HMACSHA1Sign：签名结果");
}
public string HMACSHA1Sign(string appId, string secretKey, string url, long timeStamp)
{
	var plainText = $"{appId}&{url.ToLower()}&{timeStamp}";

	plainText.Dump("HMACSHA1Sign：签名串");
	secretKey.Dump("HMACSHA1Sign：密钥");
	using (HMACSHA1 mac = new HMACSHA1(Encoding.UTF8.GetBytes(secretKey)))
	{
		var hash = mac.ComputeHash(Encoding.UTF8.GetBytes(plainText));
		var pText = Encoding.UTF8.GetBytes(plainText);
		var all = new byte[hash.Length + pText.Length];
		Array.Copy(hash, 0, all, 0, hash.Length);
		Convert.ToBase64String(hash).Dump("hash");
		Array.Copy(pText, 0, all, hash.Length, pText.Length);
		Convert.ToBase64String(pText).Dump("pText");
		return Convert.ToBase64String(all);
	}
}
public static string ToBase64hmac(string strText, string strKey)

{

	HMACSHA1 myHMACSHA1 = new HMACSHA1(Encoding.UTF8.GetBytes(strKey));

	byte[] byteText = myHMACSHA1.ComputeHash(Encoding.UTF8.GetBytes(strText));

	return System.Convert.ToBase64String(byteText);

}
public static class Extension
{
	public static long ToUnixTime(this DateTime nowTime)
	{
		DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
		return (long)Math.Round((nowTime - startTime).TotalMilliseconds, MidpointRounding.AwayFromZero);
	}

	public static DateTime UnxiToTime(this long unixTime)
	{
		DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
		return dtStart.AddSeconds(unixTime);
	}
}
// Define other methods and classes here