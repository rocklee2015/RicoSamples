<Query Kind="Statements" />

//正则表达式获取CSS里面的图片的例子，里面有URL里面的图片地址有双引号，要注意用两个双引号""表示
Regex reg1 = new Regex(@"url\((['""]?)(.+[^'""])\1\)");  //注意里面的引号 要用双引号表示，而不是用反斜杠
Console.WriteLine(reg1.Match(@"{background-image:url(//ssl.gstatic.com/ui/v1/menu/checkmark.png);backgro")); //输出 url(//ssl.gstatic.com/ui/v1/menu/checkmark.png)

//带组名的后向引用在C#中是 \k<num> ，匹配重复单词的例子：
Regex reg2 = new Regex(@"\b(?<group>\w+ +)\k<group>");
string str = "what the hell are you you talking about?";
Console.WriteLine(reg2.Match(str));