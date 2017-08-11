using System;

namespace Rico.S06.UnitySample.Unity1
{
    public class NullLogger : ILogger
    {
        public void Log(string value)
        {
            Console.WriteLine("NullLogger：Nothing to do！");
        }
    }
}
