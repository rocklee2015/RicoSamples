using System;
using System.Diagnostics;
using System.Threading;

namespace Rico.S01.ThreadSample.C3_ThreadPool
{
    /// <summary>
    /// 线程和并行度
    /// </summary>
    class S3ThreadPoolAndParallel
    {
        static void ExcuteMain()
        {
            const int numberOfOperations = 500;
            var sw = new Stopwatch();
            sw.Start();
            UseThreads(numberOfOperations);
            sw.Stop();
            Console.WriteLine("Execution time using threads: {0}", sw.ElapsedMilliseconds);

            sw.Reset();
            sw.Start();
            UseThreadPool(numberOfOperations);
            sw.Stop();
            Console.WriteLine("Execution time using threads: {0}", sw.ElapsedMilliseconds);
        }

        static void UseThreads(int numberOfOperations)
        {
            using (var countdown = new CountdownEvent(numberOfOperations))
            {
                Console.WriteLine("Scheduling work by creating threads");
                for (int i = 0; i < numberOfOperations; i++)
                {
                    var thread = new Thread(() => {
                        Console.Write("{0},", Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(TimeSpan.FromSeconds(0.1));
                        countdown.Signal();
                    });
                    thread.Start();
                }
                countdown.Wait();
                Console.WriteLine();
            }
        }

        static void UseThreadPool(int numberOfOperations)
        {
            using (var countdown = new CountdownEvent(numberOfOperations))
            {
                Console.WriteLine("Starting work on a threadpool");
                for (int i = 0; i < numberOfOperations; i++)
                {
                    ThreadPool.QueueUserWorkItem(_ => {
                        Console.Write("{0},", Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(TimeSpan.FromSeconds(0.1));
                        countdown.Signal();
                    });
                }
                countdown.Wait();
                Console.WriteLine();
            }
        }
    }
}
