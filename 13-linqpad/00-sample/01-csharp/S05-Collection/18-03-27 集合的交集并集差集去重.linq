<Query Kind="Program" />

void Main()
{
	Test_合并两个数组并去掉重复元素然后排序();

	Test_Distinct();

	Test_Union();

	Test_Concat();

	Test_Intersect();
	
	Test_Except();
}

void Test_合并两个数组并去掉重复元素然后排序()
{
	List<int> numbers1 = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 12, 10 };
	List<int> numbers2 = new List<int>() { 15, 14, 11, 13, 19, 18, 16, 17, 12, 10 };
	var newQuerty = numbers1.Concat(
	from n in numbers2
	where !numbers1.Contains(n)
	select n
	).OrderBy(n => n);
	string count = "";
	foreach (int i in newQuerty)
	{
		count += i + ",";
	}
	count.Dump("合并两个数组并去掉重复元素然后排序");
}

void Test_Distinct()
{
	List<int> list = new List<int>() { 1, 2, 3, 4, 4, 5, 6, 6 };
	var newlist = list.Distinct();
	newlist.Dump("去除重复元素");
}

void Test_Union()
{
	List<int> list = new List<int>() { 1, 2, 3, 4, 4, 5, 6, 6 };
	List<int> list1 = new List<int>() { 5, 6, 6, 7, 8, 9 };
	var newlist = list.Union(list1);
	newlist.Dump("连接不同集合，自动过滤相同项");
}

void Test_Concat()
{
	List<int> list = new List<int>() { 1, 2, 3, 4, 4, 5, 6, 6 };
	List<int> list1 = new List<int>() { 5, 6, 6, 7, 8, 9 };
	var newlist = list.Concat(list1);
	newlist.Dump("连接不同集合，不会自动过滤相同项；");
}

void Test_Intersect()
{
	List<int> list = new List<int>() { 1, 2, 3, 4, 4, 5, 6, 6 };
	List<int> list1 = new List<int>() { 5, 6, 6, 7, 8, 9 };
	var newlist = list.Intersect(list1);
	newlist.Dump("获取不同集合的相同项（交集）");
}
void Test_Except()
{
	List<int> list = new List<int>() { 1, 2, 3, 4, 4, 5, 6, 6 };
	List<int> list1 = new List<int>() { 5, 6, 6, 7, 8, 9 };
	var newlist = list.Except(list1);
	newlist.Dump("(Except)从某集合中删除其与另一个集合中相同的项；其实这个说简单点就是某集合中独有的元素");
}
// Define other methods and classes here
