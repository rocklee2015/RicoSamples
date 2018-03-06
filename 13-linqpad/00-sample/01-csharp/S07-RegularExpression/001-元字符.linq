<Query Kind="Statements" />

/*
【常用元字符】
代码    说明
.   	匹配除换行符以外的任意字符
\w  	匹配字母或数字或下划线或汉字
\s  	匹配任意的空白符
\d  	匹配数字
\b  	匹配单词的开始或结束
^   	匹配行的开始
$		匹配行的结束
*/

/*
【常用反义元字符】
代码    	说明
\W    		匹配任意不是字母，数字，下划线，汉字的字符
\S 			匹配任意不是空白符的字符
\D 			匹配任意非数字的字符
\B 			匹配不是单词开头或结束的位置
[^ x]   	匹配除了x以外的任意字符
[^ aeiou]  	匹配除了aeiou这几个字母以外的任意字符
*/

/*
【常用重复限定符】
代码	　　　　　　说明
*	　　　　　　　  重复零次或更多次
+	　　　　　　　  重复一次或更多次
?	　　　　　　　  重复零次或一次
{n}	　　　　　　    重复n次
{n,}	　　　　　  重复n次或更多次
{n,m}	　　　　    重复n到m次
*/


/*
脱字符 ^   ：表示匹配行首的文本
美元符  $　：表示匹配行尾的文本
*/

/*
^cat  匹配以c作为一行的第一个字符是c，然后是一个a，紧接着一个t的文本
例如一个行　　catdogcat　　上面正则表达式匹配第一个cat。
*/

/*
【特殊正则说明】：
^cat$     匹配行开头是cat，然后就是行末尾的cat，说白了就是一行中仅仅只包含cat的行，没有其他字符。
^$        匹配行开头，然后就是行末尾了，说白了就是匹配一个空行(没有任何字符，也没有空白字符)
^         匹配行的开头，每一行都匹配
*/

//************ 示例一：最容易理解的字符 ************
var reg = new Regex("^cat");
reg.Match("catdog");
reg.Match("catdog").Dump();     //输出 cat
reg.Match("dogcat").Dump();     //输出 空白(啥都不输出)

reg = new Regex("cat$");
reg.Match("catdog").Dump();      //输出 空白(啥都不输出)
reg.Match("dogcat").Dump();      //输出 cat

//************ 示例二：字符组  [] ************
/*
[]    字符串用中括号括起来，表示匹配其中的任一字符，相当于或的意思
例如：gr[ea]y   匹配grey或gray
其中连字符 - 表示一个范围，例如<h[1-6]> 与 <h[123456]>的作用一致。其他类似的还有[a-z]，[A-Z]。
这里必须要注意的是只有在字符组内部连字符 - 才是元字符，否则它就只匹配普通的连字符 - 。
【在[]里面是没有元字符的，都代表本身的含义，例如[.]就表示匹配一个点.的意思】
*/
var reg2 = new Regex("<h[1-6]>");
string str = "<div><h1>你在他乡还好吗？</h1></div>";
reg2.Match(str).Dump();

//************ 示例三：排除型字符组 [^] ************
/*　
用[^...]取代[...]这个字符组就会匹配任何未列出的字符。
例如：r[^abc]r　　匹配出rar,rbr,rcr之外的任意r*r文本
*/
Regex reg3 = new Regex("a[^123456]");
reg3.Match("a1a2a3a4a5a6a7").Dump(); //输出 a7

//************ 示例四：点号.匹配任意字符 ************
/*
元字符.是用来匹配任意字符的字符组的渐变写法
*/
var reg4 = new Regex(".c");
reg4.Match("abcdefg").Dump(); //输出 bc

//************ 示例五：多选结构 ************
/*
| 是一个非常简捷的元字符，它的意思是或。依靠它，我们能够把不同的子表达式组合成一个总的表达式，而这个总表达式又能够匹配任意的子表达式。
例如：gray|grey    既可匹配gray又可匹配grey    相当于gr[ae]y
【强调】：如果将|写在中括号[]里面，那么 | 就不是元字符，它和a e一样，只代表本身字符

^from|subject|date:　　与　　^(from|subject|date):　　之间的区别

　　对于前者：只能匹配 ^from 或 subject 或 date:

　　对于后者: 能够匹配 ^from: 或 ^subject: 或 ^date:
*/
Regex reg5 = new Regex("abc|def");
reg5.Match("bcdefg").Dump("示例5-1");     //输出 def

reg5 = new Regex("^from|subject|date");
reg5.Match("from you asubject").Dump("示例5-2-1");    // from
reg5.Match("a from you asubject").Dump("示例5-2-2");  // subject  (from 不是首行开头所以匹配不到)
reg5.Match("a \r\nfrom you asubject").Dump("示例5-2-3");//subject (这样竟然也不行)

reg5 = new Regex("^(from|subject|date)");
reg5.Match("from you asubject").Dump("示例5-3-1");    //from
reg5.Match("a from you asubject").Dump("示例5-3-2");  //空
reg5.Match("date from you asubject").Dump("示例5-3-3");  //date


//************ 示例六：忽略大小写 ************
/*
当然忽略大小写你可以用 [Aa]bc　　取代  abc　　，但是这样不方便。正则表达式提供一个　　-i　　。用于忽略大小写匹配。
之前写的是 -i 后来发现是错的，应该是?i  (?i)放在前面就可以了
我测试过(?i)写在前面，但是无法匹配，【要忽略大小写貌似要通过构造函数的属性设定】：
*/
Regex reg6 = new Regex("Abc", RegexOptions.IgnoreCase);
reg6.Match("abcdefg").Dump();     //输出 abc

//************ 示例七：单词分界符 ************
/*
\b　　表示单词分界符
*/
Regex reg7 = new Regex(@"\bLove\b");
reg7.Match("I Love You!").Dump();     //输出 Love