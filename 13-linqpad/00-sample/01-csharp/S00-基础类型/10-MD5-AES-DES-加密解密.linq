<Query Kind="Program">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{

	var str = DateTime.Now.ToString("yyyyMMddHHmmss");
	var key = "ricolee";
	var strChina = "ricolee中";
	//MD5
	var result = EncryptKit.ToLowerMd5(str, Encoding.UTF8);
	result.Dump("UTF8-MD5");
	result.Length.Dump();

	//MD5
	result = EncryptKit.ToLowerMd5(strChina, Encoding.UTF8);
	result.Dump("UTF8-MD5");
	result.Length.Dump();


	//MD5
	result = EncryptKit.ToLowerMd5(str, Encoding.Default);
	result.Dump("Default-MD5");

	result = EncryptKit.ToLowerMd5("8888Time", Encoding.Default);
	result.Dump("丽水-Token");

	//MD5
	result = EncryptKit.ToLowerMd5_2(str, Encoding.Default);
	result.Dump("Default-MD5");

	//SHA256
	result = EncryptKit.ToSHA256(str);
	result.Dump("SHA256 加密");

	//Base64
	result = EncryptKit.EncodeBase64(str);
	result.Dump("Base64 加密");
	result = EncryptKit.DecodeBase64(result);
	result.Dump("Base64 解密");

	//AES
	result = EncryptKit.AESEncode(str, key);
	result.Dump("AES 加密");
	result = EncryptKit.AESDecode(result, key);
	result.Dump("AES 解密");

	//DES
	result = EncryptKit.DESEncode(str, key);
	result.Dump("DES 加密");
	result = EncryptKit.DESDecode(result, key);
	result.Dump("DES 解密");
}
public static class EncryptKit
{

	#region string ToLowerMd5(string value, Encoding encoding)

	public static string ToLowerMd5(Stream stream)
	{
		using (var provider = new MD5CryptoServiceProvider())
		{
			var bytes = provider.ComputeHash(stream);
			var stringBuilder = new StringBuilder(bytes.Length * 2);
			foreach (byte data in bytes)
			{
				stringBuilder.Append(data.ToString("x").PadLeft(2, '0'));
			}
			return stringBuilder.ToString();
		}
	}

	public static string ToLowerMd5(byte[] bytes)
	{
		using (var provider = new MD5CryptoServiceProvider())
		{
			bytes = provider.ComputeHash(bytes);
			var stringBuilder = new StringBuilder(bytes.Length * 2);
			foreach (byte data in bytes)
			{
				stringBuilder.Append(data.ToString("x").PadLeft(2, '0'));
			}
			return stringBuilder.ToString();
		}
	}

	public static string ToLowerMd5(string value, Encoding encoding)
	{
		try
		{
			byte[] bytes = encoding.GetBytes(value);
			using (var provider = new MD5CryptoServiceProvider())
			{
				bytes = provider.ComputeHash(bytes);
				var stringBuilder = new StringBuilder(bytes.Length * 2);
				foreach (byte data in bytes)
				{
					stringBuilder.Append(data.ToString("x").PadLeft(2, '0'));
				}
				return stringBuilder.ToString();
			}
		}
		catch
		{
			return null;
		}
	}
	public static string ToLowerMd5_2(string value, Encoding encoding)
	{
		try
		{
			byte[] bytes = encoding.GetBytes(value);
			using (var provider = new MD5CryptoServiceProvider())
			{
				bytes = provider.ComputeHash(bytes);
				var stringBuilder = new StringBuilder(bytes.Length * 2);
				foreach (byte data in bytes)
				{
					stringBuilder.Append(data.ToString("x2"));
				}
				return stringBuilder.ToString();
			}
		}
		catch
		{
			return null;
		}
	}

	#endregion

	#region string ToLowerMd5(string value) MD5加密(小写)
	/// <summary>
	///  MD5加密(小写)
	/// </summary>
	/// <param name="value">被加密字符串</param>
	/// <returns></returns>
	public static string ToLowerMd5(string value)
	{
		return ToLowerMd5(value, Encoding.Default);
	}

	#endregion

	#region string ToUpperMd5(string value) MD5加密(大写)
	/// <summary>
	///  MD5加密(大写)
	/// </summary>
	/// <param name="value">被加密字符串</param>
	/// <returns></returns>
	public static string ToUpperMd5(string value)
	{
		byte[] bytes = Encoding.Default.GetBytes(value);
		using (var provider = new MD5CryptoServiceProvider())
		{
			bytes = provider.ComputeHash(bytes);
			var stringBuilder = new StringBuilder(bytes.Length * 2);
			foreach (byte data in bytes)
			{
				stringBuilder.Append(data.ToString("X").PadLeft(2, '0'));
			}
			return stringBuilder.ToString();
		}

	}
	#endregion

	#region ToSHA256 SHA256加密
	/// <summary>
	/// SHA256加密
	/// </summary>
	/// <param name="targetString">原始字符串</param>
	/// <returns>加密后字符串</returns>
	public static string ToSHA256(string targetString)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(targetString);
		using (var managed = new SHA256Managed())
		{
			byte[] result = managed.ComputeHash(bytes);
			return Convert.ToBase64String(result);  //返回长度为44字节的字符串
		}
	}
	#endregion

	#region Base64 加解密
	/// <summary>
	/// 进行 Base64 加密
	/// </summary>
	/// <param name="value">被加密字符串</param>
	/// <returns></returns>
	public static string EncodeBase64(string value)
	{
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
	}

	/// <summary>
	/// 进行 Base64 解密
	/// </summary>
	/// <param name="value">被解密字符串</param>
	/// <returns></returns>
	public static string DecodeBase64(string value)
	{
		return Encoding.UTF8.GetString(Convert.FromBase64String(value));
	}
	#endregion


	#region AES加解密

	//默认密钥向量
	private static readonly byte[] AESKeys = { 0x41, 0x72, 0x65, 0x79, 0x6F, 0x75, 0x6D, 0x79, 0x53, 0x6E, 0x6F, 0x77, 0x6D, 0x61, 0x6E, 0x3F };

	public static string AESEncode(string encryptString, string encryptKey)
	{
		encryptKey = StringKit.CutString(encryptKey, 32, string.Empty);
		encryptKey = encryptKey.PadRight(32, ' ');

		using (var managed = new RijndaelManaged { Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32)), IV = AESKeys })
		using (var transform = managed.CreateEncryptor())
		{
			byte[] inputDatas = Encoding.UTF8.GetBytes(encryptString);
			byte[] encryptedData = transform.TransformFinalBlock(inputDatas, 0, inputDatas.Length);
			return Convert.ToBase64String(encryptedData);
		}

	}

	public static string AESDecode(string decryptString, string decryptKey)
	{
		try
		{
			decryptKey = StringKit.CutString(decryptKey, 32, string.Empty);
			decryptKey = decryptKey.PadRight(32, ' ');

			using (var managed = new RijndaelManaged { Key = Encoding.UTF8.GetBytes(decryptKey), IV = AESKeys })
			using (var transform = managed.CreateDecryptor())
			{
				byte[] inputDatas = Convert.FromBase64String(decryptString);
				byte[] decryptedData = transform.TransformFinalBlock(inputDatas, 0, inputDatas.Length);
				return Encoding.UTF8.GetString(decryptedData);
			}
		}
		catch
		{
			return string.Empty;
		}

	}

	#endregion

	#region DES加解密

	//默认密钥向量
	private static readonly byte[] DESKeys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

	/// <summary>
	/// DES默认密钥
	/// </summary>
	private const string DESDefaultKey = "1qaz~xsw2";

	/// <summary>
	/// DES加密
	/// </summary>
	/// <param name="encryptString">待加密的字符串</param>
	/// <param name="encryptKey">加密密钥,要求为8位</param>
	/// <returns></returns>
	public static string DESEncode(string encryptString, string encryptKey)
	{
		encryptKey = StringKit.CutString(encryptKey, 8, string.Empty);
		encryptKey = encryptKey.PadRight(8, ' ');

		byte[] customizedKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
		byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);

		using (var serviceProvider = new DESCryptoServiceProvider())
		using (var stream = new MemoryStream())
		using (var cryptoStream = new CryptoStream(stream, serviceProvider.CreateEncryptor(customizedKey, DESKeys), CryptoStreamMode.Write))
		{
			cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
			cryptoStream.FlushFinalBlock();
			return Convert.ToBase64String(stream.ToArray());
		}
	}

	/// <summary>
	/// DES加密（调用类库中默认密钥）
	/// </summary>
	/// <param name="encryptString">待加密的字符串</param>
	/// <returns></returns>
	public static string DESEncode(string encryptString)
	{
		return DESEncode(encryptString, DESDefaultKey);
	}

	/// <summary>
	/// DES解密
	/// </summary>
	/// <param name="decryptString">待解密的字符串</param>
	/// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
	/// <returns></returns>
	public static string DESDecode(string decryptString, string decryptKey)
	{
		try
		{
			decryptKey = StringKit.CutString(decryptKey, 8, string.Empty);
			decryptKey = decryptKey.PadRight(8, ' ');

			byte[] customizedKey = Encoding.UTF8.GetBytes(decryptKey);
			byte[] inputByteArray = Convert.FromBase64String(decryptString);

			using (var serviceProvider = new DESCryptoServiceProvider())
			using (var stream = new MemoryStream())
			using (var cryptoStream = new CryptoStream(stream, serviceProvider.CreateDecryptor(customizedKey, DESKeys), CryptoStreamMode.Write))
			{
				cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
				cryptoStream.FlushFinalBlock();
				return Encoding.UTF8.GetString(stream.ToArray());
			}
		}
		catch (Exception)
		{
			return string.Empty;
		}
	}

	/// <summary>
	/// DES解密（调用系统默认密钥解密）
	/// </summary>
	/// <param name="decryptString">待解密的字符串</param>
	/// <returns></returns>
	public static string DESDecode(string decryptString)
	{
		return DESDecode(decryptString, DESDefaultKey);
	}

	#endregion

}
// Define other methods and classes here