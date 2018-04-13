<Query Kind="Program">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

//https://blog.csdn.net/blizzardlyk/article/details/52155184
void Main()
{
	var source = "123465789";
	var result = MD5(source);
	result.Dump("MD5 大写");
	
	result = MD52(source);
	result.Dump("MD5 小写");
	
	//CF8CDD8D0B7B1ACDA76201F406BED81E
	//CF8CDD8D0B7B1ACDA76201F406BED81E
	result = MD52("api_key=F685600641B15980&media_id=gh_560e659c5877&nonce_str=5151DCD43A67E8F2D37D1CE6FCBE275D&sign=CF8CDD8D0B7B1ACDA76201F406BED81E&timestamp=1523345599&key=C641F433488A06B596072B92D48B2200");
	result.Dump();

}
//大写
public static String MD5(string s)
{
	char[] hexDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
	MD5 md5 = new MD5CryptoServiceProvider();
	byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(s);
	byte[] result = md5.ComputeHash(inputBytes);
	int j = result.Length;
	char[] str = new char[j * 2];
	int k = 0;
	for (int i = 0; i < j; i++)
	{
		byte byte0 = result[i];
		str[k++] = hexDigits[byte0 >> 4 & 0xf];
		str[k++] = hexDigits[byte0 & 0xf];
	}
	return new String(str);


}
//小写
public static String MD52(string s)
{
	char[] hexDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
	MD5 md5 = new MD5CryptoServiceProvider();
	byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(s);
	byte[] result = md5.ComputeHash(inputBytes);
	int j = result.Length;
	char[] str = new char[j * 2];
	int k = 0;
	for (int i = 0; i < j; i++)
	{
		byte byte0 = result[i];
		str[k++] = hexDigits[byte0 >> 4 & 0xf];
		str[k++] = hexDigits[byte0 & 0xf];
	}
	return new String(str);


}


// Define other methods and classes here