using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rico.ThreadBookSamples.C5_Csharp5AndAsyncAwait
{
    class S3UseAwatiInSeriesTask
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
            var containerTask = new Task(() => {
                Task<string> t = GetInfoAsync("TPL 1");
                t.ContinueWith(task => {
                    Console.WriteLine(t.Result);
                    Task<string> t2 = GetInfoAsync("TPL 2");
                    t2.ContinueWith(innerTask => Console.WriteLine(innerTask.Result),
                        TaskContinuationOptions.NotOnFaulted | TaskContinuationOptions.AttachedToParent);
                    t2.ContinueWith(innerTask => Console.WriteLine(innerTask.Exception.InnerException),
                        TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.AttachedToParent);
                },
                    TaskContinuationOptions.NotOnFaulted | TaskContinuationOptions.AttachedToParent);

                t.ContinueWith(task => Console.WriteLine(t.Exception.InnerException),
                    TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.AttachedToParent);
            });

            containerTask.Start();
            return containerTask;
        }

        static async Task AsynchronyWithAwait()
        {
            try
            {
                Console.WriteLine("Curent Thread Id {0}", Thread.CurrentThread.ManagedThreadId);
                var result = GetInfoAsync("Async 1");
                Console.WriteLine("开始执行下一句代码.......");
                string result1 = await GetInfoAsync("Async 2");
                Console.WriteLine(result1);
                Console.WriteLine(await result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static async Task<string> GetInfoAsync(string name)
        {
            Console.WriteLine("Task {0} started!", name);
            //Thread.Sleep(2);
            int delay = 5;
            if (name == "Async 1")
                delay = 10;
            await Task.Delay(TimeSpan.FromSeconds(delay));
            if (name == "TPL 2")
                throw new Exception("Boom!");
            return string.Format("Task {0} is running on a thread id {1}. Is thread pool thread: {2}",
                name, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
        }
    }
}
