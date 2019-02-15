<Query Kind="Program" />

void Main()
{
	string myString = "  this is a string   ";
	
	myString.Dump("原字符串");
    myString.Trim().Dump("Trim");
	myString.Replace(" ", "").Dump("replace");
	
	"----------含制表符、换行页、空格-----------".Dump();
	
	myString = "  this\n is\r a \tstring   ";
	myString.Dump("原字符串");
    myString.Trim().Dump("Trim");
	myString.Replace(" ", "").Dump("replace");
	
	//匹配任何空白字符，包括空格，制表符，换页符等，与[\f\n\t\r\v]等效
	Regex.Replace(myString, @"\s", "").Dump("replace-正则");
}

// Define other methods and classes here
