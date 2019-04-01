using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S02.YouMustKnowNet
{
    public class S01_String
    {
        public void Execute1_1()
        {
            string s1 = "abc";
            Console.WriteLine(string.IsInterned(s1) ?? "null");
        }

        public void Execute1_2()
        {
            string s1 = "ab";
            s1 += "c";
            Console.WriteLine(string.IsInterned(s1) ?? "null");

        }

        public void Execute1_3()
        {
            string s1 = "abc";
            string s2 = "ab";
            s2 += "c";

            string s3 = "ab";

            Console.WriteLine(string.IsInterned(s1) ?? "null");
            Console.WriteLine(string.IsInterned(s2) ?? "null");

            Console.WriteLine(string.IsInterned(s3) ?? "null");

        }
        //---------------第二关-------------------------
        public void Execute2_1()
        {
            string s1 = "abc";
            string s2 = "ab";
            string s3 = s2 + "c";

            Console.WriteLine(string.IsInterned(s3) ?? "null");

        }

        public void Execute2_2()
        {
            string s2 = "ab";
            s2 += "c";

            Console.WriteLine(string.IsInterned(s2) ?? "null");

            string s1 = "abc";

        }


        public void Execute2_3()
        {
            string s2 = "ab";
            s2 += "c";

            Console.WriteLine(string.IsInterned(s2) ?? "null");

            string s1 = GetStr();

        }
        private static string GetStr()
        {
            return "abc";
        }
        //---------------第三关-------------------------

        public const string s7 = "abc";
        public static string s8 = "abc";
        public void Execute3_1()
        {
            string s2 = "ab";
            s2 += "c";
            Console.WriteLine(string.IsInterned(s2) ?? "null");
        }
        public void Execute3_2()
        {
            string s2 = "ab";
            s2 += "c";
            Console.WriteLine(string.IsInterned(s2) ?? "null");
        }
    }
}
