<Query Kind="Program" />

void Main()
{
	var list = Enumerable.Range(1, 100);
	var result = list.Aggregate((a, b) => (a + b));
	Console.WriteLine(string.Format("1到100的和为{0}", result));

	//
	var strList = new List<string>() {"aa","bb","cc"};
	string.Join(",",strList).Dump("string join");
	
	strList.Aggregate((x,y)=>x+","+y).Dump("Aggregate");


	//1~n放在含有n+1个元素的数组中，只有唯一的一个元素值重复，最简算法找出重复的数
	int[] array = new int[] { 1, 3, 2, 3, 4, 5 };

	array.Select((i, j) => i - j).Dump();
	//原极限算法
	int repeatedNum1 = array.Select((i, j) => i - j).Sum().Dump();
	//最新极限算法
	int repeatedNum2 = array.Aggregate((a, n, i) => a + n - i).Dump();
}


// Define other methods and classes here
