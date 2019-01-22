using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S01.ConfigManagerAndComplie
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = ConfigurationManager.AppSettings["name"];
#if DEBUG
            Console.WriteLine("DEBUG");
            Console.WriteLine($"name:{name}");
#elif TEST_DEBUG
            Console.WriteLine("TEST_DEBUG");
            Console.WriteLine($"name:{name}");
#elif TEST_RELEASE
            Console.WriteLine("TEST_RELEASE");
            Console.WriteLine($"name:{name}");
#elif PRE
            Console.WriteLine("PRE");
            Console.WriteLine($"name:{name}");
#elif RELEASE
            Console.WriteLine("RELEASE");
            Console.WriteLine($"name:{name}");
#endif
            Console.WriteLine("结束");
            Console.ReadKey();

        }
    }
}
