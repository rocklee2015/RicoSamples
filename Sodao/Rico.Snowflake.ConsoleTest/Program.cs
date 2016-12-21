using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snowflake.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const int workerId = 0x6;
            const int datacenterId = 0;
            var worker = new IdWorker(workerId, datacenterId);
            const long WorkerMask = 0x000000000001F000L;
            long prev = 0;
            for (var i = 0; i < 1000; i++)
            {
                var id = worker.NextId();
                var expected = (id & WorkerMask) >> 12;
                var isGreatThan = id - prev ;
                prev = id;
                Console.WriteLine(id + "\t" + isGreatThan);
                Thread.Sleep(50);
            }
        }
    }
}
