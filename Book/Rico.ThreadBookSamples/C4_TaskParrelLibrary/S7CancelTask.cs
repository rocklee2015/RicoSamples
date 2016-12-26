using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rico.ThreadBookSamples.C4_TaskParrelLibrary
{
    class S7CancelTask
    {
        private static void ExcuteMain()
        {
            var cts = new CancellationTokenSource();
            //一、给底层任务传递一次取消标记，在任务启动前取消是TPL的事，代码根本不会执行，如果尝试执行则得到InvalidOperationException异常；
            var longTask = new Task<int>(() => TaskMethod("Task 1", 10, cts.Token), cts.Token);
            Console.WriteLine(longTask.Status);
            cts.Cancel();
            Console.WriteLine(longTask.Status);
            Console.WriteLine("First task has been cancelled before execution");
            cts = new CancellationTokenSource();
            longTask = new Task<int>(() => TaskMethod("Task 2", 10, cts.Token), cts.Token);
            longTask.Start();
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine(longTask.Status);
            }
            cts.Cancel();
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine(longTask.Status);
            }

            Console.WriteLine("A task has been completed with result {0}.", longTask.Result);
            Console.ReadKey();
        }
        //二、自己写代码处理取消过程，我们对过程全权负责，并且取消后，任务状态仍然是RanToCompletion.因为在TPL看来任务正常完成了！
        private static int TaskMethod(string name, int seconds, CancellationToken token)
        {
            Console.WriteLine("Task {0} is running on a thread id {1}. Is thread pool thread: {2}",
                name, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
            for (int i = 0; i < seconds; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                if (token.IsCancellationRequested) return -1;
            }
            return 42 * seconds;
        }
    }
}
