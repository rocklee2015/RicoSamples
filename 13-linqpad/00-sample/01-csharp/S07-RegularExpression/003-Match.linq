<Query Kind="Statements" />

/*
Regex在匹配的时候，常常会返回一个Match类的对象，今天就来看看怎么玩这个对象。

一、属性

Captures 　　按从里到外、从左到右的顺序获取由捕获组匹配的所有捕获的集合（如果正则表达式用 RegexOptions..::.RightToLeft 选项修改了，则顺序为按从里到外、　　　　　　　从右到左）。该集合可以有零个或更多的项。
Empty 　　　 获取空组。所有失败的匹配都返回此空匹配。 
Groups 　　   获取由正则表达式匹配的组的集合。 
Index 　　　  原始字符串中发现捕获的子字符串的第一个字符的位置。 
Length 　　   捕获的子字符串的长度。
Success 　　  获取一个值，该值指示匹配是否成功。
Value 　　　　从输入字符串中获取捕获的子字符串。

二、方法

NextMatch 　　　　从上一个匹配结束的位置（即在上一个匹配字符之后的字符）开始返回一个包含下一个匹配结果的新 Match。 
Result 　　　　　　返回对指定替换模式的扩展。 
Synchronized 　　 返回一个与提供的实例等效的 Match 实例，该实例适合在多个线程间共享。 
ToString 　　　　  从输入字符串中获取捕获的子字符串。 （继承自 Capture。）
*/

Regex reg = new Regex(@"(?<数字分组>\d+)abc");
Match m = reg.Match("s123abcdefg");
Console.WriteLine(m.Success);   //输出 True   指示匹配是否成功
Console.WriteLine(m.Value);     //输出 123abc 获取匹配到的子字符串
Console.WriteLine(m.Length);    //输出 6  匹配的子字符串的长度，其实m.value.Length不就行了吗
Console.WriteLine(m.Index);     //输出 1  获取匹配到的子字符串的第一个字符在整个输入字符串的位置
GroupCollection GColl = m.Groups;
foreach (Group g in GColl)
{                                   //        整个组  自定义组
	Console.WriteLine(g.Success);   //输出    True    True
	Console.WriteLine(g.Index);     //输出    1       1
	Console.WriteLine(g.Length);    //输出    6       3
	Console.WriteLine(g.Value);     //输出    123abc  123
}

Console.WriteLine(Match.Empty);     //输出 空白(啥都不输出，空匹配，所有失败的匹配都返回此空匹配)
CaptureCollection CColl = m.Captures;
foreach (Capture c in CColl)
{
	Console.WriteLine(c.Index);     //输出 1
	Console.WriteLine(c.Length);    //输出 6
	Console.WriteLine(c.Value);     //输出 123abc
}

Regex reg2 = new Regex(@"\d+");
Match m2 = reg2.Match("123abc456");
Console.WriteLine(m2.Value);    //输出 123
Match m2_1 = m2.NextMatch();
Console.WriteLine(m2_1.Value);    //输出 456

Match m2_2 = Match.Synchronized(m2_1);  //获取一个与实例等效的Match实例用于多线程共享
Console.WriteLine(m2_2.Value);    //输出 456

Console.WriteLine(m2_1.ToString());   //输出 456

Regex reg3 = new Regex(@"\d+");
Match m3_1 = reg3.Match("123ABC");
Console.WriteLine(m3_1.Result("$'")); //输出 ABC  不要迷惑 这个需要了解下replacement  http://www.cnblogs.com/kissdodog/archive/2013/04/25/3043173.html

//-----------------------------------
Regex reg4 = new Regex(@"\d+");

//第一种方法是利用Matches方法，返回所有匹配到的字符串的集合
MatchCollection MColl = reg4.Matches("123abc456");
foreach (Match match in MColl)
{
	Console.WriteLine(match.Value);     //输出 123 456
}

//第二种方法是利用Match类的NextMatch()方法
Match m4_2 = reg4.Match("123abc456");
while (m4_2.Success)
{
	Console.WriteLine(m4_2.Value);    //同样输出 123 456
	m4_2 = m4_2.NextMatch();
}