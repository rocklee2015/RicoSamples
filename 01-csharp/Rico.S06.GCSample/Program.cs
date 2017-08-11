using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S06.GCSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //计算执行该段代码需要多少内存
            long start = GC.GetTotalMemory(true);//

            //do something
            
            GC.Collect();
            GC.WaitForFullGCComplete();
            long end = GC.GetTotalMemory(true);
            long useMemory = end - start;
        }

    }
}
