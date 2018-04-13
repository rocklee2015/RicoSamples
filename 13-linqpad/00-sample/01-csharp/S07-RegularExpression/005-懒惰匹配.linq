<Query Kind="Statements" />

/*
懒惰匹配

代码/语法 　　　　　　说明
*?	　　　　　　　　　重复任意次，但尽可能少重复
+?	　　　　　　　　　重复1次或更多次，但尽可能少重复
??	　　　　　　　　　 重复0次或1次，但尽可能少重复
{n,m}?	　　　　　　  重复n到m次，但尽可能少重复
{n,}?	　　　　　　　  重复n次以上，但尽可能少重复

如果你细心的留意到，会发现，其实懒惰匹配符只是在原有限定符后面加了个？以表示尽可能少地匹配的意思。
*/

//懒惰匹配
Regex reg1 = new Regex(@"A(\w)*B");
Console.WriteLine(reg1.Match("A12B34B56B"));    //输出 A12B34B56B //留意到默认是尽可能多地匹配

Regex reg2 = new Regex(@"A(\w)*?B"); //\w重复任意次，但尽可能少          
Console.WriteLine(reg2.Match("A12B34B56B"));   //输出 A12B

Regex reg3 = new Regex(@"A(\w)+?");  //\w重复1次或更多次，但尽可能少
Console.WriteLine(reg3.Match("AB12B34B56B"));        //输出AB 注意此处测试字符串

Regex reg4 = new Regex(@"A(\w)??B");  //\w重复0次或1次，但尽可能少
Console.WriteLine(reg4.Match("A12B34B56B"));    //输出 空白，匹配失败，因为至少也要重复\w两次
Console.WriteLine(reg4.Match("A1B2B34B56B"));   //输出 A1B

Regex reg5 = new Regex(@"A(\w){4,10}?B");       //\w至少重复4次，最多重复10次
Console.WriteLine(reg5.Match("A1B2B3B4B5B"));   //输出 A1B2B3B    到了第4个的时候，恰好第4个字符是3只有匹配3后面的那个B了

Regex reg6 = new Regex(@"A(\w){4,}?");  //\w至少重复4次，最多无上限
Console.WriteLine(reg5.Match("A1B2B3B4B5B"));   //输出 A1B2B3B    到了第4个的时候，恰好第4个字符是3只有匹配3后面的那个B了