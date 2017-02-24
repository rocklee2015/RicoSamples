using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rico.ThreadBookSamples.C5_Csharp5AndAsyncAwait
{
    class S1GetResutInAwait
    {
        public static void ExcuteMain()
        {
            //Task t = AsynchronyWithTPL();
            //t.Wait();
            Console.WriteLine("(ExcuteMain)Current Thread Id {0},Is Thread Pool Thread:{1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
            AsynchronyWithAwait();
            //Task t = AsynchronyWithAwait();
            //t.Wait();
            Console.ReadKey();
        }

        static Task AsynchronyWithTPL()
        {
            Task<string> t = GetInfoAsync("Task 1",2);
            Task t2 = t.ContinueWith(task => Console.WriteLine(t.Result),
                TaskContinuationOptions.NotOnFaulted);
            Task t3 = t.ContinueWith(task => Console.WriteLine(t.Exception.InnerException),
                TaskContinuationOptions.OnlyOnFaulted);

            return Task.WhenAny(t2, t3);
        }

        static async Task AsynchronyWithAwait()
        {
            try
            {
                Console.WriteLine("(AsynchronyWithAwait)Current Thread Id {0},Is Thread Pool Thread:{1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                //result1 使用了await ,await作用 即从异步线程切换至主线程，将异步结果赋值给result1
                var result1 = await GetInfoAsync("Task 1", 1);
                string result2 = await GetInfoAsync("Task 2", 1);
                //Console.WriteLine(result2);
                //Console.WriteLine(result1);

                sw.Stop();
                TimeSpan ts2 = sw.Elapsed;
                Console.WriteLine("1 总共花费{0}ms.", ts2.TotalMilliseconds);
                //--------------------------------------------------------------
                sw.Reset();
                sw.Start();
                // result3 没有await,但是异步函数确实执行了，只是没有获取执行结果。这时result3只是Task,等用await,或者.Result（还有其它方式）取结果时，才切换至主线程
                var result3 = GetInfoAsync("Task 3", 1);
                var result4 =  await GetInfoAsync("Task 4", 1);
                Console.WriteLine(result4);
                Console.WriteLine(result3.Result);
                //Console.WriteLine(await result3); 同上一行代码
                sw.Stop();
                ts2 = sw.Elapsed;
                Console.WriteLine("2 总共花费{0}ms.", ts2.TotalMilliseconds);
                //--------------------------------------------------------------
                sw.Reset();
                sw.Start();
                // result3 没有await,但是异步函数确实执行了，只是没有获取执行结果。这时result3只是Task,等用await,或者.Result（还有其它方式）取结果时，才切换至主线程
                var result5 = GetInfoAsync("Task 5", 1);
                var result6 = GetInfoAsync("Task 6", 1);
                Console.WriteLine(result6.Result);
                Console.WriteLine(result5.Result);
                //Console.WriteLine(await result3); 同上一行代码
                sw.Stop();
                ts2 = sw.Elapsed;
                Console.WriteLine("3 总共花费{0}ms.", ts2.TotalMilliseconds);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        static async Task<string> GetInfoAsync(string name,int delaySecond)
        {
            await Task.Delay(TimeSpan.FromSeconds(delaySecond));
            Console.WriteLine("{0} is running ",name);
            //throw new Exception("Boom!");
            return string.Format("Task {0} is running on a thread id {1}. Is thread pool thread: {2}",
                name, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
        }
    }
}
