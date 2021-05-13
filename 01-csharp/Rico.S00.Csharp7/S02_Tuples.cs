using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//参考：https://www.cnblogs.com/cncc/p/7698543.html

namespace Rico.S00.Csharp7
{
    [TestClass]
    public class S02_Tuples
    {
        /// <summary>
        /// Net4 老版本Tuple用法
        /// </summary>
        [TestMethod]
        public void Net4_Tuple_Test1()
        {
            //元组：允许方法返回一个以上的返回值
            /*
            .NET 4中的Tuple两个缺点：

            1）Tuple 会影响代码的可读性，因为它的属性名都是：Item1，Item2.. 。
            2）Tuple 还不够轻量级，因为它是引用类型（Class）

            C# 7 中的元组（ValueTuple）解决了上述两个缺点：

            1）ValueTuple 支持语义上的字段命名。
            2）ValueTuple 是值类型（Struct）。

            */
            var fullName = GetFullName();

            Console.WriteLine(fullName.Item1);// Item1,2,3不能忍，，,
            Console.WriteLine(fullName.Item2);
            Console.WriteLine(fullName.Item3);
        }

        static Tuple<string, string, string> GetFullName() => new Tuple<string, string, string>("first name", "blackheart", "last name");

        [TestMethod]
        public void Csharp7_Tuple_Test()
        {

            //需要安装包：System.ValueTuple
            var tuple = (1, 2);                           // 使用语法糖创建元组
            var tuple2 = ValueTuple.Create(1, 2);         // 使用静态方法【Create】创建元组
            var tuple3 = new ValueTuple<int, int>(1, 2);  // 使用 new 运算符创建元组

            Console.WriteLine($"first：{tuple.Item1}, second：{tuple.Item2}, 上面三种方式都是等价的。");
            Console.WriteLine($"first：{tuple2.Item1}, second：{tuple2.Item2}, 上面三种方式都是等价的。");
            Console.WriteLine($"first：{tuple3.Item1}, second：{tuple3.Item2}, 上面三种方式都是等价的。");
        }

        /// <summary>
        ///  如何创建给字段命名的元组？
        /// </summary>
        [TestMethod]
        public void Csharp7_Tuple_Test2()
        {
            // 左边指定字段名称
            (int one, int two) tuple = (1, 2);
            Console.WriteLine($"first：{tuple.one}, second：{tuple.two}");

            // 右边指定字段名称
            var tuple2 = (one: 1, two: 2);
            Console.WriteLine($"first：{tuple2.one}, second：{tuple2.two}");

            // 左右两边同时指定字段名称
            (int one, int two) tuple3 = (first: 1, second: 2);    
            /* 此处会有警告：由于目标类型（xx）已指定了其它名称，因为忽略元组名称xxx */
            Console.WriteLine($"first：{tuple3.one}, second：{tuple3.two}");
        }

        /// <summary>
        /// 解构元组
        /// </summary>
        [TestMethod]
        public void Csharp7_Tuple_Test3()
        {
            var (one, two) = GetTuple();

            Console.WriteLine($"first：{one}, second：{two}");
           
        }
        static (int, int) GetTuple()
        {
            return (1, 2);
        }
    }
}
