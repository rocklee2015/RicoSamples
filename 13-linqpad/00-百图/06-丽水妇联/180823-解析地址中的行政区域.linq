<Query Kind="Program" />

void Main()
{
	//https://github.com/cn/GB2260.cs
	//var pattern = "(?<province>[^省]+自治区|.*?省|.*?行政区|.*?市)(?<city>[^市]+自治州|.*?市|.*?县|[^小]+区)(?<county>[^县]+县|[^小]+区|.+市|.+旗|.+海域|.+岛)?(?<town>[^乡]+乡|.+镇)?(?<village>.*)";
	var pattern = "(?<province>[^省]+自治区|.*?省|.*?行政区|.*?市)(?<county>[^市]+自治州|.*?市|.*?县|[^小]+区)?(?<town>[^乡]+乡|.+镇|[^小]+区|.+街道)?(?<village>.*)";
	var regex = new Regex(pattern);
	var addressList = new List<string>() {
	 "江苏省睢宁县古邳镇吴口村1号",
	 "浙江省杭州市西湖区文一西路522号4幢1单元",
	 "浙江省丽水市莲都区东苑小区１7幢402室",
	 "浙江省缙云县五云街道鼎龙小区39幢2单元502室",
	  "北京市海淀区上地十街10号",
	  "江苏省静安市恒丰路600号机电大厦",
	   "上海市静安区恒丰路600号机电大厦"
	};
	foreach (var address in addressList)
	{
		var result = regex.Match(address);
		address.Dump("地址");
		foreach (var groupName in regex.GetGroupNames())
		{
			var val = String.Format("<{0}>{1}", groupName,
				result.Groups[regex.GroupNumberFromName(groupName)].Value);
			val.Dump();
		}
	}

	//result.Dump();
}

// Define other methods and classes here