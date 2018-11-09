<Query Kind="Program" />

void Main()
{
	StringToDateTime("19830327").Dump();
}
public DateTime? StringToDateTime(string dateTimeString)
{
	DateTime result = DateTime.MinValue;
	if (dateTimeString.Length == 8)
	{
		var year = dateTimeString.Substring(0, 4);
		var month = dateTimeString.Substring(4, 2);
		var day = dateTimeString.Substring(6, 2);

		if (DateTime.TryParse(year + "-" + month + "-" + day, out result))
		{
			return result;
		}
	}
	return null;
}
// Define other methods and classes here