using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rico.ThreadBookSamples.C3_ThreadPool
{
    class S5WaitEventOrTimeOutInThreadPool
    {
        static void ExcuteMain()
        {
            //因为操作需要6秒才能执行完，所以5秒的超时限制，操作肯定超时了
            RunOperations(TimeSpan.FromSeconds(5));
            RunOperations(TimeSpan.FromSeconds(7));
        }

        static void RunOperations(TimeSpan workerOperationTimeout)
        {
            using (var evt = new ManualResetEvent(false))
            using (var cts = new CancellationTokenSource())
            {
                Console.WriteLine("Registering timeout operations...");
                //注册一个超时等待处理器
                var worker = ThreadPool.RegisterWaitForSingleObject(evt,
                    (state, isTimedOut) => WorkerOperationWait(cts, isTimedOut), null, workerOperationTimeout, true);

                Console.WriteLine("Starting long running operation...");

                ThreadPool.QueueUserWorkItem(_ => WorkerOperation(cts.Token, evt));

                Thread.Sleep(workerOperationTimeout.Add(TimeSpan.FromSeconds(2)));
                worker.Unregister(evt);
            }
        }
        //耗时操作，运行6秒，一旦成功则设置信号类，被取消则丢弃
        static void WorkerOperation(CancellationToken token, ManualResetEvent evt)
        {
            for (int i = 0; i < 6; i++)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            evt.Set();
        }
        //等待事件处理器，
        static void WorkerOperationWait(CancellationTokenSource cts, bool isTimedOut)
        {
            if (isTimedOut)
            {
                cts.Cancel();
                Console.WriteLine("Worker operation timed out and was canceled.");
            }
            else
            {
                Console.WriteLine("Worker operation succeded.");
            }
        }
    }
}
