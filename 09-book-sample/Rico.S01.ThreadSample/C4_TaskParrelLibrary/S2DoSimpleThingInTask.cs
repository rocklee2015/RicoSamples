using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rico.S01.ThreadSample.C4_TaskParrelLibrary
{
    class S2DoSimpleThingInTask
    {
        static void ExcuteMain()
        {
            //普通调用，在主线程中
            TaskMethod("Main Thread Task");
            //Task1：使用线程池线程，并且主线程等待，直到任务返回前一直处于阻塞状态；
            Task<int> task = CreateTask("Task 1");
            task.Start();
            int result = task.Result;
            Console.WriteLine("Result is: {0}", result);
            //Task2：同Task1 ，方式不同
            task = CreateTask("Task 2");
            task.RunSynchronously();
            result = task.Result;
            Console.WriteLine("Result is: {0}", result);
            //Task3：没有阻塞主线程，只是在任务完成前循环打印任务状态；
            task = CreateTask("Task 3");
            Console.WriteLine(task.Status);
            task.Start();

            while (!task.IsCompleted)
            {
                Console.WriteLine(task.Status);
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }

            Console.WriteLine(task.Status);
            result = task.Result;
            Console.WriteLine("Result is: {0}", result);
        }
        static Task<int> CreateTask(string name)
        {
            return new Task<int>(() => TaskMethod(name));
        }
        static int TaskMethod(string name)
        {
            Console.WriteLine("Task {0} is running on a thread id {1}. Is thread pool thread: {2}",
                name, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            return 42;
        }
    }
}
