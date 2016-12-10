using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Csharp.Samples.StringSample
{
    /// <summary>
    /// 字符串驻留
    /// </summary>
    public class StringIntern
    {
        public static string s1 = "abc";
        public void Excute()
        {
            //string s1 = "ab";
            //s1 += "c";
            //Console.WriteLine(string.IsInterned(s1) ?? "null");


            //string s1 = "abcd";
            //Console.WriteLine(string.IsInterned(s1) ?? "null");

            //string s4 = s1;
            //Console.WriteLine(string.IsInterned(s4) ?? "null");

            //Console.WriteLine(ReferenceEquals(s4, s1));
            //s1 = "wzy";
            //Console.WriteLine(s1);
            //Console.WriteLine(s4);
            //Console.WriteLine(string.IsInterned(s1) ?? "null");
            //Console.WriteLine(string.IsInterned(s4) ?? "null");

            //string s2 = "ab";
            //Console.WriteLine(string.IsInterned(s2) ?? "null");

            //s2 += "c";
            //Console.WriteLine(string.IsInterned(s2) ?? "null");

            //string s3 = "abf";

            //Console.WriteLine(string.IsInterned(s3) ?? "null");


            //string s1 = "abc";
            //string s2 = "ab";
            //string s3 = s2+"c";
            //Console.WriteLine(string.IsInterned(s3) ?? "null");

            string strA = "abcdef";
            string strB = "abcdef";
            Console.WriteLine(ReferenceEquals(strA, strB));
            strA = "abcd";
            strA = "abcdef";

            Console.WriteLine(ReferenceEquals(strA, strB));
            Console.WriteLine(string.IsInterned(strA) ?? "null");
            Console.WriteLine(string.IsInterned(strB) ?? "null");

            //string strC = "abc";
            //string strD =strC+ "def";
            //Console.WriteLine(string.IsInterned(strD) ?? "null");
            //Console.WriteLine(ReferenceEquals(strA, strD));


            //string s2 = "ab";
            //s2 += "c";
            //Console.WriteLine(string.IsInterned(s2) ?? "null");
            //string s1 = GetStr();
            // Thread.GetDomain().IsStringInterned(strA);
            Console.ReadKey();
        }
    }
}
