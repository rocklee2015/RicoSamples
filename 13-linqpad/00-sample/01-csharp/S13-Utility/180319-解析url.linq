<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.EnterpriseServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.RegularExpressions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ComponentModel.DataAnnotations.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.Protocols.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceProcess.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Utilities.v4.0.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Framework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.Build.Tasks.v4.0.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Caching.dll</Reference>
  <Namespace>System.Collections.Specialized</Namespace>
  <Namespace>System.Web</Namespace>
</Query>

void Main()
{
	//(C#获取URL参数值)https://www.cnblogs.com/gaizai/archive/2010/05/27/1743485.html
	string pageURL = "http://www.google.com.hk/search?hl=zh-CN&source=hp&q=%E5%8D%9A%E6%B1%87%E6%95%B0%E7%A0%81&aq=f&aqi=g2&aql=&oq=&gs_rfai=klj==";
	Uri uri = new Uri(pageURL);
	string queryString = uri.Query;
	NameValueCollection col = GetQueryString(queryString);
	string searchKey = col["q"];
	//结果 searchKey = "博汇数码"
	foreach (var item in col)
	{
		$"{item}={col[item.ToString()]}".Dump();
	}
}



/// <summary>
/// 将查询字符串解析转换为名值集合.
/// </summary>
/// <param name="queryString"></param>
/// <returns></returns>
public static NameValueCollection GetQueryString(string queryString)
{
	return GetQueryString(queryString, null, true);
}

/// <summary>
/// 将查询字符串解析转换为名值集合.
/// </summary>
/// <param name="queryString"></param>
/// <param name="encoding"></param>
/// <param name="isEncoded"></param>
/// <returns></returns>
public static NameValueCollection GetQueryString(string queryString, Encoding encoding, bool isEncoded)
{
	queryString = queryString.Replace("?", "");
	NameValueCollection result = new NameValueCollection(StringComparer.OrdinalIgnoreCase);
	if (!string.IsNullOrEmpty(queryString))
	{
		int count = queryString.Length;
		for (int i = 0; i < count; i++)
		{
			int startIndex = i;
			int index = -1;
			while (i < count)
			{
				char item = queryString[i];
				if (item == '=')
				{
					if (index < 0)
					{
						index = i;
					}
				}
				else if (item == '&')
				{
					break;
				}
				i++;
			}
			string key = null;
			string value = null;
			if (index >= 0)
			{
				key = queryString.Substring(startIndex, index - startIndex);
				value = queryString.Substring(index + 1, (i - index) - 1);
			}
			else
			{
				key = queryString.Substring(startIndex, i - startIndex);
			}
			if (isEncoded)
			{
				result[MyUrlDeCode(key, encoding)] = MyUrlDeCode(value, encoding);
			}
			else
			{
				result[key] = value;
			}
			if ((i == (count - 1)) && (queryString[i] == '&'))
			{
				result[key] = string.Empty;
			}
		}
	}
	return result;
}

/// <summary>
/// 解码URL.
/// </summary>
/// <param name="encoding">null为自动选择编码</param>
/// <param name="str"></param>
/// <returns></returns>
public static string MyUrlDeCode(string str, Encoding encoding)
{
	if (encoding == null)
	{
		Encoding utf8 = Encoding.UTF8;
		//首先用utf-8进行解码                     
		string code = HttpUtility.UrlDecode(str.ToUpper(), utf8);
		//将已经解码的字符再次进行编码.
		string encode = HttpUtility.UrlEncode(code, utf8).ToUpper();
		if (str == encode)
			encoding = Encoding.UTF8;
		else
			encoding = Encoding.GetEncoding("gb2312");
	}
	return HttpUtility.UrlDecode(str, encoding);
}
// Define other methods and classes here
