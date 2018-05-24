<Query Kind="Program" />

void Main()
{
var  strOne="781018(13735907999)";
var strTwo="坏人活千年(13695799697)";

	"============".Dump();
	PadRightEx(strOne,30,'*').Dump();
	PadRightEx(strOne,30,'*').Length.Dump();
	PadRightEx(strTwo, 30, '*').Dump();
	PadRightEx(strTwo, 30, '*').Length.Dump();
	Console.Write(PadRightEx("asdf.", 12, '*') + "\r\n");
	Console.Write(PadRightEx("中文Ec", 12, '*') + "\r\n");
	
	//方案一
	var name="781018(13735907999";
	string tmpname = name + new string('*', 50 - Encoding.Default.GetByteCount(name));
	tmpname.Dump();
	name="坏人活千(13695799697)";
	tmpname = name + new string('*', 50 - Encoding.GetEncoding("gb2312").GetByteCount(name));
	tmpname.Dump();
}
private string PadRightEx(string str, int totalByteCount, char c)
{
	Encoding coding = Encoding.GetEncoding("gb2312");
	int dcount = 0;
	foreach (char ch in str.ToCharArray())
	{
		if (coding.GetByteCount(ch.ToString()) == 2)
			dcount++;
	}
	if (dcount == 0)
	{
	  return  str.PadRight(totalByteCount - dcount, c);
	}
	else
	{
	   return  str.PadRight(totalByteCount - dcount+dcount/2, c);
	}
}
// Define other methods and classes here
