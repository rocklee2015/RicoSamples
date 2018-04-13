<Query Kind="Statements" />


//1. 匹配html标签内容
string d = "阿斯蒂芬<span class=\"g\">  www.100jnled.com/ 2012-9-28  </span>阿士大夫的";
Regex reg = new Regex(@"(?<=<span[^>]*?class=""g""[^>]*?>).*?(?=</span>)");
if (reg.IsMatch(d))
{
	Console.Write(reg.Match(d));  //输出 www.100jnled.com/ 2012-9-28 
}

//2.
string tag="a",html="<a href='www.csdn.net' class='main' >CSDN</a>";
string tmpStr = string.Format("<{0}[^>]*?>(?<Text>[^<]*)</{1}>", html, tag); //获取<title>之间内容

Match TitleMatch = Regex.Match(html, tmpStr, RegexOptions.IgnoreCase);

string result = TitleMatch.Groups["Text"].Value;
result.Dump();

//3.
string tag3="a",html3="<a href='www.csdn.net' class='main' >CSDN</a>",attriName="href";
string tmpStr3 = string.Format("<{0}[^>]*?{1}=(['\"\"]?)(?<url>[^'\"\"\\s>]+)\\1[^>]*>", html3, tag3,attriName); //获取<title>之间内容

Match TitleMatch3 = Regex.Match(html3, tmpStr3, RegexOptions.IgnoreCase);

string result3 = TitleMatch3.Groups["url"].Value;
result3.Dump();