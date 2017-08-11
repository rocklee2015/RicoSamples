using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S03.ReferenceType
{
    /// <summary>
    /// 字符串驻留
    /// </summary>
    public class StringIntern
    {
        //IsInterned ：字符串位于驻留池时，则返回对字符串的引用(如果是字符串常量则返回驻留池中的引用，若是动态生成字符串则返回其新地址引用,因为哈希表不维护动态生成字符串)，否则将返回null引用；
        //Intern ：字符串位于驻留池，则返回字符的引用，否则将该字符串添加到驻留池(哈希表)，并返回引用

        // 注意：驻留池

        public static void Test1()
        {
            string str = "abc";
            Console.WriteLine(string.IsInterned(str) ?? "null");  //abc
        }
        public static void Test2()
        {
            string str = "ab";
            str += "c";
            Console.WriteLine(string.IsInterned(str) ?? "null");  //null
        }
        public static void Test3()
        {
            string str1 = "abc";
            string str2 = "ab";

            str2 += "c";

            string str3 = "ab";

            Console.WriteLine(string.IsInterned(str1) ?? "null");  //abc
            Console.WriteLine(string.IsInterned(str2) ?? "null");  //abc   
            Console.WriteLine(ReferenceEquals(str1, str2));         //False
            //动态字符串str2在驻留池中存在，所以返回字符串引用，但为什么不是驻留池str1的引用
            //在做+运算时，如果参数有变量，会在堆中创建新对象，不会在拘留池中新建对象
            Console.WriteLine(string.IsInterned(str3) ?? "null");  //ab
        }
        public static void Test4()
        {
            string str1 = "abc";
            string str2 = "ab";
            string str3 = str2 + "c";

            Console.WriteLine(string.IsInterned(str3) ?? "null");  //abc
            Console.WriteLine(ReferenceEquals(str1, str3));        //False
        }
        public static void Test5()
        {
            string str2 = "ab";
            str2 += "c";

            Console.WriteLine(string.IsInterned(str2) ?? "null");  //abc str1('abc')在编译时期就放进驻留池了

            string str1 = "abc";

        }
        public static void Test6()
        {
            string str2 = "ab";
            str2 += "c";

            Console.WriteLine(string.IsInterned(str2) ?? "null");  //null  编译时期没法执行方法，所以abc不在驻留池

            string str1 = GetString();
        }

        private static string GetString()
        {
            return "abc";
        }
        #region
        //public const string constStr = "abc";
        public static void Test7()
        {
            string str2 = "ab";
            str2 += "c";

            Console.WriteLine(string.IsInterned(str2) ?? "null");  //null 无论取消或者不取消上面注释，结果都为null
        }
        #endregion

        #region
        //public static string staticStr = "abc";
        public static void Test8()
        {
            string str2 = "ab";
            str2 += "c";

            Console.WriteLine(string.IsInterned(str2) ?? "null");  //如果取消上面注释，结果为abc,不取消结果为null
        }
        #endregion
        public static void Test9()
        {
            string str1 = "abc";
            string str2 = "ab";
            string str3 = str2 + "c";

            Console.WriteLine(string.IsInterned(str3) ?? "null");  //abc

            Console.WriteLine(ReferenceEquals(str1, str2));  //false

        }

        public static void Test10()
        {
            //使用构造器，创建字符串时，不用驻留池
            string a = new string(new char[] { 'a', 'b' }); //string 只接受 char*,char []类型
            string b = new string(new char[] { 'a', 'b' });
            Console.WriteLine(a == b);                //true
            Console.WriteLine(a.Equals(b));         //true
            Console.WriteLine(ReferenceEquals(a, b));//False
        }

        public static void Test11()
        {
            //字符常量
            string a = "ab";
            string b = "ab";
            Console.WriteLine(a == b);               //True
            Console.WriteLine(a.Equals(b));          //True
            Console.WriteLine(ReferenceEquals(a, b));//True
        }


    }
}
