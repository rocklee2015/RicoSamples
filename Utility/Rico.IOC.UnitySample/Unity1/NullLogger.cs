using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.IOC.UnitySample.Unity1
{
    public class NullLogger : ILogger
    {
        public void Log(string value)
        {
            Console.WriteLine("NullLogger：Nothing to do！");
        }
    }
}
