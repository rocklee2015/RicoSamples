using System;

namespace Rico.S06.AutoFacSample.model2
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
