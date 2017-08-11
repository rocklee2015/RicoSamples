using System;
using System.Threading;

namespace Rico.S01.ThreadSample.C2_ThreadSynchronization
{
    class ManualResetEventSlimMethod
    {
        #region
        //一开始设置为false才会等待收到信号才执行
        static ManualResetEvent mr = new ManualResetEvent(false);
        public static void ExecuteMain()
        {
            Thread t = new Thread(Run);
            //启动辅助线程
            t.Start();
            //等待辅助线程执行完毕之后，主线程才继续执行
            Console.WriteLine("主线程一边做自己的事，一边等辅助线程执行!" + DateTime.Now.ToString("mm:ss"));
            mr.WaitOne();
            Console.WriteLine("收到信号，主线程继续执行" + DateTime.Now.ToString("mm:ss"));
            Console.ReadKey();
        }
        static void Run()
        {
            //模拟长时间任务
            Thread.Sleep(3000);
            Console.WriteLine("辅助线程长时间任务完成！" + DateTime.Now.ToString("mm:ss"));
            mr.Set();
        }
        #endregion
        #region
        static ManualResetEventSlim _mainEvent = new ManualResetEventSlim(false);
        public static void ExecuteMain(string arg)
        {
            var t1 = new Thread(() => TravelThroughGates("Thread 1", 5));
            var t2 = new Thread(() => TravelThroughGates("Thread 2", 6));
            var t3 = new Thread(() => TravelThroughGates("Thread 3", 12));
            t1.Start();
            t2.Start();
            t3.Start();
            Thread.Sleep(TimeSpan.FromSeconds(6));
            Console.WriteLine("The gates are now open!");
            _mainEvent.Set();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _mainEvent.Reset();
            Console.WriteLine("The gates have been closed!");
            Thread.Sleep(TimeSpan.FromSeconds(10));
            Console.WriteLine("The gates are now open for the second time!");
            _mainEvent.Set();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("The gates have been closed!");
            _mainEvent.Reset();
        }
        static void TravelThroughGates(string threadName, int seconds)
        {
            Console.WriteLine("{0} falls to sleep", threadName);
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            Console.WriteLine("{0} waits for the gates to open!", threadName);
            _mainEvent.Wait();

            Console.WriteLine("{0} enters the gates!", threadName);
        }
        #endregion
    }
}
