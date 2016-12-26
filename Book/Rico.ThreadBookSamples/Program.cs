using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rico.ThreadBookSamples.C2_ThreadSynchronization;

namespace Rico.ThreadBookSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            SpinWaitMethod.ExcuteMain(null);

            Console.ReadKey();
        }
    }
}
