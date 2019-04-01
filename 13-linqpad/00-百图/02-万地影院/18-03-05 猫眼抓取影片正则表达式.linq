<Query Kind="Program" />

void Main()
{

	var regex = new Regex("^http://maoyan.com/films/\\d+$", RegexOptions.Compiled);
	var result = regex.IsMatch("http://maoyan.com/films/1196183");
	result.Dump();

	//var regex2 = new Regex("^http://maoyan.com/films\\?showType=[1-2]&offset=\\d+$", RegexOptions.Compiled);
	var regex2 = new Regex("^http://maoyan.com/films\\?showType=[1|2][&ci=50]*[&offset=0|&offset=30]*$", RegexOptions.Compiled);
	//var regex2 = new Regex("^http://maoyan.com/films\\?showType=1&offset=[0-120]+$", RegexOptions.Compiled);
	var urls = new List<string>() {
	 "http://maoyan.com/films?offset=30",
	  "http://maoyan.com/films?showType=1",
		"http://maoyan.com/films?showType=2",
		"http://maoyan.com/films?showType=3",
		"http://maoyan.com/films?showType=3&offset=30",
		"http://maoyan.com/films?showType=3&ci=50&offset=0",
		"http://maoyan.com/films?showType=3&ci=50&offset=30",
	 "http://maoyan.com/films?showType=1&ci=50&offset=0",
	 "http://maoyan.com/films?showType=1&ci=50&offset=30",
	 "http://maoyan.com/films?showType=1&ci=50&offset=60",
	 "http://maoyan.com/films?showType=1&ci=50&offset=80",
	  "http://maoyan.com/films?showType=2&ci=50&offset=0",
	 "http://maoyan.com/films?showType=2&ci=50&offset=30",
	  "http://maoyan.com/films?showType=2&ci=50&offset=60",
	};
	foreach (var url in urls)
	{
		regex2.IsMatch(url).Dump(url + "是否匹配");
	}


	var regex3 = new Regex("^https://news.cnblogs.com/n/\\d+/$", RegexOptions.Compiled);
	var result3 = regex3.IsMatch("https://news.cnblogs.com/n/590988/");
	result3.Dump();

	var regex4 = new Regex("^http://maoyan.com/films\\?showType=[1-2]&offset=[0-120]$", RegexOptions.Compiled);
	var result4 = regex4.IsMatch("http://maoyan.com/films?showType=1&offset=0");
	result4.Dump();

	var maoYanUrl = "http://maoyan.com/films?showType=2&offset=30";
	var showTypeValue = GetQueryString("showType", maoYanUrl);
	showTypeValue.Dump();
}

public string GetQueryString(string name, string url)
{
	System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(@"(^|&)?(\w+)=([^&]+)(&|$)?", System.Text.RegularExpressions.RegexOptions.Compiled);
	System.Text.RegularExpressions.MatchCollection mc = re.Matches(url);
	foreach (System.Text.RegularExpressions.Match m in mc)
	{
		if (m.Result("$2").Equals(name))
		{
			return m.Result("$3");
		}
	}
	return "";
}

// Define other methods and classes here