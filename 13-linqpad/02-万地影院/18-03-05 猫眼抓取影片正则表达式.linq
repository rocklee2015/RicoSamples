<Query Kind="Program" />

void Main()
{

	var regex = new Regex("^http://maoyan.com/films/\\d+$", RegexOptions.Compiled);
	var result = regex.IsMatch("http://maoyan.com/films/1196183");
	result.Dump();

	//var regex2 = new Regex("^http://maoyan.com/films\\?showType=[1-2]&offset=\\d+$", RegexOptions.Compiled);
	var regex2 = new Regex("^http://maoyan.com/films\\?showType=1&offset=[0|30|60|90|120]+$", RegexOptions.Compiled);
    //var regex2 = new Regex("^http://maoyan.com/films\\?showType=1&offset=[0-120]+$", RegexOptions.Compiled);
	var urls = new List<string>() {
	 "http://maoyan.com/films",
	 "http://maoyan.com/films?showType=1&offset=30",
	 "http://maoyan.com/films?showType=1&offset=60",
	 "http://maoyan.com/films?showType=1&offset=80",
	 "http://maoyan.com/films?showType=1&offset=81",
	 "http://maoyan.com/films?showType=1&offset=89",
	 "http://maoyan.com/films?showType=1&offset=90",
	 "http://maoyan.com/films?showType=1&offset=99",
	 "http://maoyan.com/films?showType=1&offset=100",
	 "http://maoyan.com/films?showType=1&offset=120",
	 "http://maoyan.com/films?showType=1&offset=tt"
	};
	foreach (var url in urls)
	{
	   regex2.IsMatch(url).Dump(url+"是否匹配");
	}


	var regex3 = new Regex("^https://news.cnblogs.com/n/\\d+/$", RegexOptions.Compiled);
	var result3 = regex3.IsMatch("https://news.cnblogs.com/n/590988/");
	result3.Dump();

	var regex4 = new Regex("^http://maoyan.com/films\\?showType=[1-2]&offset=[0-120]$", RegexOptions.Compiled);
    var result4 = regex4.IsMatch("http://maoyan.com/films?showType=1&offset=0");
	result4.Dump();

	
}

// Define other methods and classes here