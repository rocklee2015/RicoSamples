<Query Kind="Statements" />

/*
小括号的作用

分类 　　　　代码/语法 　　　　说明

捕获　　　　
　　　　　　(exp) 　　　　　　 匹配exp,并捕获文本到自动命名的组里
　　　　　　(?<name>exp)	　 匹配exp,并捕获文本到名称为name的组里，也可以写成(?'name'exp)
　　　　　　(?:exp)	　　　　   匹配exp,不捕获匹配的文本，也不给此分组分配组号
零宽断言	
　　　　　　(?=exp)	　　　　	匹配exp前面的位置
　　　　　　(?<=exp)	　　　  匹配exp后面的位置
　　　　　　(?!exp)	　　　　  匹配后面跟的不是exp的位置
　　　　　　(?<!exp)	　　　　匹配前面不是exp的位置
注释	
　　　　　　(?#comment)	这种类型的分组不对正则表达式的处理产生任何影响，用于提供注释让人阅读

要特别注意的是，零宽断言是不占用位置的，也就是说，匹配结果里是不会返回它的。

 (?:exp)　既不捕获匹配的文本，也不给此分组分配组号，这个东西到底有什么用呢？

 (?:exp) 非捕获组，匹配exp的内容，但不捕获到组里

至于作用，一般来说是为了节省资源，提高效率
比如说验证输入是否为整数，可以这样写
^([1-9][0-9]*|0)$
这时候我们需要用到()来限制“|”表示“或”关系的范围，但我们只是要判断规则，没必要把exp匹配的内容保存到组里，这时就可以用非捕获组了
^(?:[1-9][0-9]*|0)$

　　有的时候我们不得不用()，而()默认情况下会将其中exp匹配的内容捕获到组里，而有些情况我们只是判断规则，或者后面并不需要对此处()中匹配的内容进行引用时，就没有必要把它捕获到组里了，一方面会造成资源的浪费，另一方面会降低效率，这时候就要用到非捕获组了。

至于这些东西，说是说不明白的，看符号也没用，最好就是上例子。
*/

//(exp) 匹配exp,并捕获文本到自动命名的组里
Regex reg = new Regex(@"A(\w+)A");
Console.WriteLine(reg.Match("dsA123A"));    //输出 A123A
Console.WriteLine(reg.Match("dsA123A").Groups[1]);      //输出123

//(?<name>exp)    匹配exp,并捕获文本到名称为name的组里，也可以写成(?'name'exp)
Regex reg2 = new Regex(@"A(?<num>\w+)A");
Console.WriteLine(reg2.Match("dsA123A").Groups["num"]); //输出123

Regex reg3 = new Regex(@"A(?:\w+A)");
Console.WriteLine(reg3.Match("dsA123A"));

Console.WriteLine("==============================");

//(?=exp)    匹配exp前面的位置  零宽正预测先行断言
Regex reg4 = new Regex(@"sing(?=ing)");     //表达式的意思是，我认为在sing的后面会有ing，如果sing后面紧跟着ing，那么这个sing才匹配成功，注意断言词不会被匹配
Console.WriteLine(reg4.Match("ksingkksingingkkk"));     //输出    sing
Console.WriteLine(reg4.Match("singddddsingingd").Index);   //输出 8   输出8就意味住前面那个sing被没有被匹配

//(?<=exp) 匹配exp后面的位置  零宽度正回顾后发断言
Regex reg5 = new Regex(@"(?<=wo)man");
Console.WriteLine(reg5.Match("Hi man Hi woman"));   //输出 man
Console.WriteLine(reg5.Match("Hi man Hi woman").Index);     //输出 12    掰着手指头算算到底匹配的是哪一个

//(?!exp)    匹配后面跟的不是exp的位置 零宽度负预测先行断言
Regex reg6 = new Regex(@"sing(?!ing)");
Console.WriteLine(reg6.Match("singing-singabc"));   //输出 sing
Console.WriteLine(reg6.Match("singing-singabc").Index); //输出 8  还得掰着手指头算算匹配的是哪一个

//(?<!exp)    匹配前面不是exp的位置 零宽度负回顾后发断言
Regex reg7 = new Regex(@"(?<!wo)man");
Console.WriteLine(reg7.Match("Hi woman Hi man"));   //输出 man
Console.WriteLine(reg7.Match("Hi woman Hi man").Index); //输出 12  算算匹配的是哪一个

//(?#comment)    不对正则表达式的处理产生任何影响，用于提供注释让人阅读
Regex reg8 = new Regex("ABC(?#这只是一段注释而已)DEF");
Console.WriteLine(reg8.Match("ABCDEFG"));   //输出 ABCDEF