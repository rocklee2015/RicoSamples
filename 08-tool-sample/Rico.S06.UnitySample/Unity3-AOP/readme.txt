2018-08-08

https://www.cnblogs.com/zh7791/p/7923305.html

Nuget : Unity 版本是4.0.1 ,当装5.3.1 时，运行不了这个程序

需要引用一下两个包：
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.Unity;


注意：
这里的顺序（order）并不能代表Handler执行顺序，没弄明白这是怎么个执行顺序？