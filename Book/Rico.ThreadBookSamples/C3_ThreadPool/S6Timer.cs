using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rico.ThreadBookSamples.C3_ThreadPool
{
    class S6Timer
    {
        static void ExcuteMain()
        {
            Console.WriteLine("Press 'Enter' to stop the timer...");
            DateTime start = DateTime.Now;
            _timer = new Timer(_ => TimerOperation(start), null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2));

            Thread.Sleep(TimeSpan.FromSeconds(6));

            _timer.Change(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(4));

            Console.ReadLine();

            _timer.Dispose();
        }

        static Timer _timer;

        static void TimerOperation(DateTime start)
        {
            TimeSpan elapsed = DateTime.Now - start;
            Console.WriteLine("{0} seconds from {1}. Timer thread pool thread id: {2}", elapsed.Seconds, start,
                Thread.CurrentThread.ManagedThreadId);
        }
    }
}
