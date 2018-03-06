<Query Kind="Program" />

void Main()
{

	var regex = new Regex("^http://maoyan.com/films/\\d+$", RegexOptions.Compiled);
	var result = regex.IsMatch("http://maoyan.com/films/1196183");
	result.Dump();

	var regex2 = new Regex("^http://maoyan.com/films\\?showType=[1-2]&offset=\\d+$", RegexOptions.Compiled);
	var result2 = regex2.IsMatch("http://maoyan.com/films?showType=1&offset=20");
	var result2_1 = regex2.IsMatch("http://maoyan.com/films");
	result2.Dump();
	result2_1.Dump();

	var regex3 = new Regex("^https://news.cnblogs.com/n/\\d+/$", RegexOptions.Compiled);
	var result3 = regex3.IsMatch("https://news.cnblogs.com/n/590988/");
	result3.Dump();

	var regex4 = new Regex("^http://maoyan.com/films\\?showType=[1-2]&offset=[0-120]$", RegexOptions.Compiled);
    var result4 = regex4.IsMatch("http://maoyan.com/films?showType=1&offset=0");
	result4.Dump();
}

// Define other methods and classes here