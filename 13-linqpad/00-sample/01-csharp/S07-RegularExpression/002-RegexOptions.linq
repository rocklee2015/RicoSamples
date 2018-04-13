<Query Kind="Statements" />

/*
 　　在C#中new一个Regex对象的时候，第二个参数能够用枚举支持选择匹配模式，现在就来说说这些枚举值对正则的影响。

　　　模式　　　　　　　　　　　　　　说明

　　　.SingleLine　　　　　　　　　　 点号能够匹配任何字符
　　　.Multiline　　　　　　　　　　　 扩展^和$的匹配，使^和$能够匹配字符串内部的换行符
　　　.IgnorePatternWhitespace　　 设计宽松排列和注释模式
　　　.IgnoreCase　　　　　　　　　 进行不区分大小写的匹配
　　  .ECMAScript　　　　　　　　　 限制\w \s \d，令其只对ASCII字符有效
　　　.RightToLeft　　　　　　　　　 传动装置的驱动过程不变，但是方向相反(从字符的末尾开始，向开头移动)
　　　.Compiled　　　　　　　　　　 多花些时间优化正则表达式，编译到dll里，占用多点内存，但是匹配更快。
　　　.ExplicitCapture　　　　　　　　普通括号()在正常情况下是捕获型括号，但是在此模式下与(?:...)一样，之分组，不捕获

【RegexOptions.Compiled的意义】

　　使用RegexOptions.Compiled与不使用RegexOptions.Compiled的对比

　　标准　　　　　　不使用　　　　　　　　　　使用

　　启动速度　　　　较快　　　　　　　　　　　较慢(最多60倍)
　　内存占用　　　　少　　　　　　　　　　　　多(每个正则表达式占用5-15KB)
　　匹配速度　　　　一般　　　　　　　　　　　最多能提升10倍

　　在使用了RegexOptons.Compiled时，在程序执行过程中，这块内存会一直被占用，无法被释放，因此仅对于那些经常被使用的正则表达式才适合使用此选项。

【ECMAScript模式】

　　要注意ECMAScript只能与下面的选项同时使用

　　RegexOptons.IgnoreCase
　　RegexOptons.Multiline
　　RegexOptons.Compiled

　　而且反斜线-数字不会有反向引用和十进制转移的二义性，因为它只能够表示反向引用。例如 \10 表示反向引用 \1 然后是文字0。如果没有启用该模式，则 \12 匹配的是ASCII进纸符linefeed。同时\w \d \s \W \D \S只能匹配ASCII。

　　另外在C#中，分组的编号也需要注意。

　　分组0是整个正则表达式匹配到的结果。

　　然后依次是未命名分组。

　　最后是命名分组。

　　例如：

　　(\w)(?<Num>\d+)(\s+)

　　　1　　　3　　　　　2

 　　特殊的Replacement处理

　　Regex.Replace方法和Match.Result方法都可以接收能够进行特殊处理的replacement字符串。下面的字符序列会被匹配到的文本所替换：

　　字符序列　　　　　　　　　　替换内容

　　$&　　　　　　　　　　　　  整个表达式匹配的文本，相当于$0

　　$1  $2　　　　　　　　　　  对应编号的捕获分组所匹配的文本

　　${name}　　　　　　　　　 对应命名捕获分组匹配的文本

　　$‘　　　　　　　　　　　　　目标字符串中匹配文本之前的文本

　　$'　　　　　　　　　　　　　目标字符串中匹配文本之后的文本

 　  $$　　　　　　　　　　　　 单个$字符($1的显示为$$!)

　　$_　　　　　　　　　　　　 正则原始目标字符串的副本

　　$+　　　　　　　　　　　　 .NET中表示最后的那个捕获型括号匹配的文本
*/

Regex reg1 = new Regex(@"\d+");
string str = reg1.Replace("123", "insert into table where id = $&");
Console.WriteLine(str);     //输出 insert into table where id = 123

Regex reg2 = new Regex(@"1\+1=(\d)");
string str2 = reg2.Replace("1+1=3", "不是$1");
Console.WriteLine(str2);    //输出 不是3

Regex reg3 = new Regex(@"1\+1=(?<result>\d)");
string str3 = reg3.Replace("1+1=3", "不是${result}");
Console.WriteLine(str3);    //输出 不是3

Regex reg4 = new Regex(@"\d+");
string str4 = reg4.Replace("123ABC", "后面是$'");  //匹配文本之后的文本
Console.WriteLine(str4);    //输出 后面是ABCABC     为什么会输出 后面是ABCABC呢？因为$'指的是ABC，然后替换掉原字符串中的123。不懂看多几次这句话

Regex reg5 = new Regex(@"\d+");
string str5 = reg5.Replace("ABC123", "前面是$`");  //ABC前面是ABC 符号是 1左边那个
Console.WriteLine(str5);

Regex reg6 = new Regex(@"\d+");
string str6 = reg6.Replace("ABC123", "右边原始输入字符串$_");
Console.WriteLine(str6);    //输出 右边是原始字符串ABC123