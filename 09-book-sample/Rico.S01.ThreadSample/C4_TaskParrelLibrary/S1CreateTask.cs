using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rico.S01.ThreadSample.C4_TaskParrelLibrary
{
    public class S1CreateTask
    {
        public static void ExcuteMain()
        {
            var taskName = "Task 1";
            var t1 = new Task(() => TaskMethod(taskName));
            var t2 = new Task(() => TaskMethod("Task 2"));
            t2.Start();
            t1.Start();
            Task.Run(() => TaskMethod("Task 3"));
            Task.Factory.StartNew(() => TaskMethod("Task 4"));
            Task.Factory.StartNew(() => TaskMethod("Task 5"), TaskCreationOptions.LongRunning);
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        static void TaskMethod(string name)
        {
            Console.WriteLine("Task {0} is running on a thread id {1}. Is thread pool thread: {2}",
                name, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
        }
    }
}
