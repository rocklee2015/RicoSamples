using System;

namespace Rico.S06.UnitySample.Unity1
{
    public class ConsoleLogger:ILogger
    {
        public void Log(string value)
        {
            Console.WriteLine("ConsoleLogger：{0}", value);
        }
    }
}
