<Query Kind="Statements" />

/*
一、属性

CacheSize 　　获取或设置已编译的正则表达式的当前静态缓存中的最大项数。 默认是15个，最近使用的15个会存在缓存中，避免重新创建。当有第16个进来会替换掉第　　　　　　　　 1个。保持15个。
Options 　　　返回传入 Regex 构造函数的选项。 
RightToLeft 　获取一个值，该值指示正则表达式是否从右向左进行搜索。

二、方法

CompileToAssembly 　　  已重载。 编译正则表达式，并将其保存到单个程序集的磁盘中。 
Escape 　　　　　　　　 通过替换为转义码来转义最小的元字符集（\、*、+、?、|、{、[、(、)、^、$、.、# 和空白）。 
GetGroupNames 　　　 	返回正则表达式的捕获组名数组。 
GetGroupNumbers 　　 	返回与数组中的组名相对应的捕获组号的数组。 
GroupNameFromNumber 　　获取与指定组号相对应的组名。 
GroupNumberFromName 　　返回与指定组名相对应的组号。 
InitializeReferences 　　 基础结构。 由 CompileToAssembly 方法生成的 Regex 对象使用。 
IsMatch 　　　　　　　　已重载。 指示正则表达式在输入字符串中是否找到匹配项。 
Match 　　　　　　　　　已重载。 在输入字符串中搜索正则表达式的匹配项，并将精确结果作为单个 Match 对象返回。 
Matches 　　　　　　　　已重载。 在输入字符串中搜索正则表达式的所有匹配项并返回所有成功的匹配，就像多次调用 Match 一样。 
Replace 　　　　　　　　已重载。 在指定的输入字符串内，使用指定的替换字符串替换与某个正则表达式模式匹配的字符串。 
Split 　　　　　　　　　  已重载。 在由正则表达式匹配项定义的位置将输入字符串拆分为一个子字符串数组。 
Unescape 　　　　　　   取消转义输入字符串中的任何转义字符。 
UseOptionC 　　　　　　基础结构。 由 CompileToAssembly 方法生成的 Regex 对象使用。 
UseOptionR 　　　　　　基础结构。 由 CompileToAssembly 方法生成的 Regex 对象使用
*/
Regex reg = new Regex(@"\d+");
Regex.CacheSize = 1000;             //最大静态缓存项数，不知道用来干嘛的
Console.WriteLine(reg.Options);     //输出 Singleline 构造函数中的选项
Console.WriteLine(reg.RightToLeft); //输出 False  是否从右向左搜索

Console.WriteLine(Regex.Escape(@"\d+"));    //输出 \\d\+  这个Escape    方法用于动态获取的变量生成的正则表达式，这时如果变量中含有正则中的元字符，会被解析成元字符，就可能会导致正则编译不通过，从而导致程序异常，需要对变量进行转义处理。比如根据用户输入的id获取Html控件，如果这个用户输入的控件id含有元字符，那么就会抛异常，这个时候就可以用Escape转码一下
Console.WriteLine(Regex.Unescape(@"\\d\+"));    //输出    \d+     反转码，获取转码之前的字符串

Console.WriteLine(reg.IsMatch("123"));      //输出 True
Console.WriteLine(reg.IsMatch("abc"));      //输出 False

Console.WriteLine(reg.Match("1a"));         //输出 1  返回精确的匹配到的结果

MatchCollection col = reg.Matches("12a34b45d");  //match与matches的区别在于match返回第一个匹配，而matches返回全部的匹配
foreach (var c in col)
{
	Console.WriteLine(c.ToString());        //输出 12 34 45
}

Console.WriteLine(reg.Replace("ab5cd", "k"));    //输出abkcd 替换正则表达式匹配到的字符，第二个参数是用于替换的字符
Console.WriteLine(reg.Replace("a1b2c3d", "k"));    //输出akbkckdk

string[] strArr = reg.Split("ab2cd");   //用匹配到的字符将字符串分割成两个字符串数组
foreach (string str in strArr)
{
	Console.WriteLine(str);     //输出 ab cd
}

Regex reg2 = new Regex(@"(?<数字分组>\d+)abc");
int[] intArr = reg2.GetGroupNumbers();
foreach (int i in intArr)
{
	Console.WriteLine(i);   //输出0 1     0始终代表整个表达式，1就是你自己括起来的我那组
}

string[] strGroup = reg2.GetGroupNames();
foreach (string str in strGroup)
{
	Console.WriteLine(str);     //输出0   数字分组    至于整个表达式指定不指定意义都不大，反正你肯定知道0是整个组
}

Console.WriteLine(reg2.GroupNameFromNumber(1)); //输出 数字分组，根据组号，获取组名
Console.WriteLine(reg2.GroupNumberFromName("数字分组"));    //输出 1  根据组名获取组号