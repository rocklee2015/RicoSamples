using System;
using System.Collections.Generic;
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
            Task t = AsynchronyWithTPL();
            t.Wait();

            t = AsynchronyWithAwait();
            t.Wait();
            Console.ReadKey();
        }

        static Task AsynchronyWithTPL()
        {
            Task<string> t = GetInfoAsync("Task 1");
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
                string result = await GetInfoAsync("Task 2");
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static async Task<string> GetInfoAsync(string name)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            //throw new Exception("Boom!");
            return string.Format("Task {0} is running on a thread id {1}. Is thread pool thread: {2}",
                name, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
        }
    }
}
