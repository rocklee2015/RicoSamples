<Query Kind="Program" />

void Main()
{
	GetTitleContent(@" <a href='www.csdn.net' class='main' >CSDN</a>", "a").Dump();           //输出CSDN
	GetTitleContent(@" <a href='www.csdn.net' class='main' >CSDN</a>", "a", "href").Dump();   //www.csdn.net
}


/// <summary>
/// 获取字符中指定标签的值
/// </summary>
/// <param name="str">字符串</param>
/// <param name="title">标签</param>
/// <returns>值</returns>
public static string GetTitleContent(string str, string title)
{
	string tmpStr = string.Format("<{0}[^>]*?>(?<Text>[^<]*)</{1}>", title, title); //获取<title>之间内容

	Match TitleMatch = Regex.Match(str, tmpStr, RegexOptions.IgnoreCase);

	string result = TitleMatch.Groups["Text"].Value;
	return result;
}
/// <summary>
/// 获取字符中指定标签的值
/// </summary>
/// <param name="str">字符串</param>
/// <param name="title">标签</param>
/// <param name="attrib">属性名</param>
/// <returns>属性</returns>
public static string GetTitleContent(string str, string title, string attrib)
{

	string tmpStr = string.Format("<{0}[^>]*?{1}=(['\"\"]?)(?<url>[^'\"\"\\s>]+)\\1[^>]*>", title, attrib); //获取<title>之间内容

	Match TitleMatch = Regex.Match(str, tmpStr, RegexOptions.IgnoreCase);

	string result = TitleMatch.Groups["url"].Value;
	return result;
}
