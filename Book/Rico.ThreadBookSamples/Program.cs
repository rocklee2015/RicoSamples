using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rico.ThreadBookSamples.C2_ThreadSynchronization;
using Rico.ThreadBookSamples.C5_Csharp5AndAsyncAwait;
using Rico.ThreadBookSamples.C9_AsynchronouseIO;

namespace Rico.ThreadBookSamples
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //SpinWaitMethod.ExcuteMain(null);
            //S6AvoidUseSynchrouseContext.ExcuteMain();
            //S9UseawaitToDynamicType.ExcuteMain();

            //S2AccessFileAsync.ExcuteMain();

            S4AccessDataBaseAsync.ExcuteMain();
            Console.ReadKey();
        }
    }
}
