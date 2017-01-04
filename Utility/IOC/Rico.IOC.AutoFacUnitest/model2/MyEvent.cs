using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.IOC.AutoFacUnitest.model2
{
    public class MyEvent : IDisposable
    {
        public MyEvent(string input)
        {
            Console.WriteLine(input);
        }

        public MyEvent()
        {
            Console.WriteLine("Init");
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }
    }
}
