using System;
using System.Threading;

namespace Rico.S01.ThreadSample.C3_ThreadPool
{
    class S2PutAsyncOperateOnThreadPool
    {
        static void ExcuteMain()
        {
            const int x = 1;
            const int y = 2;
            const string lambdaState = "lambda state 2";

            ThreadPool.QueueUserWorkItem(AsyncOperation);
            Thread.Sleep(TimeSpan.FromSeconds(1));

            ThreadPool.QueueUserWorkItem(AsyncOperation, "async state");
            Thread.Sleep(TimeSpan.FromSeconds(1));

            ThreadPool.QueueUserWorkItem(state => {
                Console.WriteLine("Operation state: {0}", state);
                Console.WriteLine("Worker thread id: {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }, "lambda state");

            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.WriteLine("Operation state: {0}, {1}", x + y, lambdaState);
                Console.WriteLine("Worker thread id: {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }, "lambda state");

            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        private static void AsyncOperation(object state)
        {
            Console.WriteLine("Operation state: {0}", state ?? "(null)");
            Console.WriteLine("Worker thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
