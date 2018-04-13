<Query Kind="Program" />

void Main()
{
	string pageURL = "http://www.google.com.hk/search?hl=zh-CN&source=hp&q=%E5%8D%9A%E6%B1%87%E6%95%B0%E7%A0%81&aq=f&aqi=g2&aql=&oq=&gs_rfai=klj==";
	var baseUrl=string.Empty;
	var result = ParseUrl(pageURL, out baseUrl);
	baseUrl.Dump("url");
	foreach (var item in result)
	{
		$"{item}={result[item.ToString()]}".Dump();
	}
}
/// <summary>
/// 分析url链接，返回参数集合
/// </summary>
/// <param name="url">url链接</param>
/// <param name="baseUrl"></param>
/// <returns></returns>
public static System.Collections.Specialized.NameValueCollection ParseUrl(string url, out string baseUrl)
{
	baseUrl = "";
	if (string.IsNullOrEmpty(url))
		return null;
	System.Collections.Specialized.NameValueCollection nvc = new System.Collections.Specialized.NameValueCollection();

	try
	{
		int questionMarkIndex = url.IndexOf('?');

		if (questionMarkIndex == -1)
			baseUrl = url;
		else
			baseUrl = url.Substring(0, questionMarkIndex);
		if (questionMarkIndex == url.Length - 1)
			return null;
		string ps = url.Substring(questionMarkIndex + 1);

		// 开始分析参数对   
		System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(@"(^|&)?(\w+)=([^&]+)(&|$)?", System.Text.RegularExpressions.RegexOptions.Compiled);
		System.Text.RegularExpressions.MatchCollection mc = re.Matches(ps);

		foreach (System.Text.RegularExpressions.Match m in mc)
		{
			nvc.Add(m.Result("$2").ToLower(), m.Result("$3"));
		}

	}
	catch { }
	return nvc;
}
// Define other methods and classes here
