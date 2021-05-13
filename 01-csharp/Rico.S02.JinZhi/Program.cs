using System;
using System.Collections.Generic;
using System.Linq;
namespace Rico.S02.JinZhi
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "151200059";
            var chars = str.ToCharArray().ToList().Select(c => int.Parse(c.ToString()));
            var result = chars.Aggregate((sum, next) =>
              {

                  Console.WriteLine("sum:{0}", sum);
                  Console.WriteLine("next:{0}", next);
                  sum = sum ^ next;
                  Console.WriteLine("本次异或结果:{0}", sum);
                  return sum;
              });
            Console.WriteLine("最终结果：{0}", result);
            Console.WriteLine("{0}%10={1}", result, result % 10);
            Console.ReadKey();
        }
        static int ConvertFromString(string str)
        {
            return 0;
        }
    }
    public class Test
    {
        public int a => aa();
        public int b { get; set; }



        public int aa()
        {
            return 0;
        }
    }
}
