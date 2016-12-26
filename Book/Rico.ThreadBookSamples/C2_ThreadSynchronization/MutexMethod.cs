using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rico.ThreadBookSamples.C2_ThreadSynchronization
{
    /// <summary>
    /// 2.Mutex
    /// </summary>
    public class MutexMethod
    {
        public static void ExecuteMain()
        {
            //该互斥量是全局的操作系统对象
            const string MutexName = "CSharpThreadingCookbook";

            using (var m = new Mutex(false, MutexName))
            {
                //获取到信号量为true,否则为false
                if (!m.WaitOne(TimeSpan.FromSeconds(20), false))
                {
                    Console.WriteLine("Second instance is running!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Running!");
                    Console.ReadLine();
                    //释放互斥量
                    m.ReleaseMutex();
                }
            }
        }
    }
}
