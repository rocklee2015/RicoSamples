using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S13.ExceptionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //var S01 = new S01_丢失StackTrace();
            //S01.Excute();
            Console.WriteLine("----------");
            var S02 = new S01_没有丢失StackTrace();
            S02.Excute();
        }
    }
}
