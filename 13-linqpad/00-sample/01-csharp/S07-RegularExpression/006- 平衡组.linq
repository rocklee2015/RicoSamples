<Query Kind="Statements" />

/*
正则表达式平衡组用于匹配左右两边开始，结束符号相等数量的内容
　　例如，对于字符串"xx <aa <bbb> <bbb> aa> yy>"	左右两边的< > 是不等的，如果简单的<.+>匹配到的是最外层的开始括号<与结束括号 
>之间的内容，但是开始和封闭的括号数量不一致。如果你希望匹配到的是左右括号正常结束的字符串，那么就需要用到平衡组了。

平衡组语法：
　　(?'group') 把捕获的内容命名为group,并压入堆栈(Stack)
　　(?'-group') 从堆栈上弹出最后压入堆栈的名为group的捕获内容，如果堆栈本来为空，则本分组的匹配失败
　　(?(group)yes|no) 如果堆栈上存在以名为group的捕获内容的话，继续匹配yes部分的表达式，否则继续匹配no部分
　　(?!) 零宽负向先行断言，由于没有后缀表达式，试图匹配总是失败
*/

//平衡组 我们现在要匹配最外层的括号的内容
string strTag = "xx <aa <bbb> <bbb> aa> yy>";   //要匹配的目标是 <aa <bbb> <bbb> aa>  ，注意括号数不等
Regex reg = new Regex("<.+>");
Console.WriteLine(reg.Match(strTag));   //输出 <aa <bbb> <bbb> aa> yy>    看到与希望匹配的目标不一致，主要是因为 < 与 > 的数量不相等

Regex reg3 = new Regex("<[^<>]*(((?'Open'<)[^<>]*)+((?'-Open'>)[^<>]+))*(?(Open)(?!))>");
Console.WriteLine(reg3.Match(strTag));  //<aa <bbb> <bbb> aa>   目标正确


//平衡组最常用的例子，匹配HTML，以下是匹配嵌套DIV里面的内容
Regex reg2 = new Regex(@"<div[^>]*>[^<>]*(((?'Open'<div[^>]*>)[^<>]*)+((?'-Open'</div>)[^<>]*)+)*(?(Open)(?!))</div>");
string str = "<a href='http://www.baidu.com'></a><div id='div1'><div id='div2'>你在他乡还好吗？</div></div><p></p>";
Console.WriteLine(reg2.Match(str));  //输出 <div id='div1'><div id='div2'>你在他乡还好吗？</div></div>

/*
语法解释：
<                         #最外层的左括号
    [^<>]*                #最外层的左括号后面的不是括号的内容
    (
        (
            (?'Open'<)    #碰到了左括号，在黑板上写一个"Open"
            [^<>]*       #匹配左括号后面的不是括号的内容
        )+
        (
            (?'-Open'>)   #碰到了右括号，擦掉一个"Open"
            [^<>]*        #匹配右括号后面不是括号的内容
        )+
    )*
    (?(Open)(?!))         #在遇到最外层的右括号前面，判断黑板上还有没有没擦掉的"Open"；如果还有，则匹配失败

>                         #最外层的右括号
*/
