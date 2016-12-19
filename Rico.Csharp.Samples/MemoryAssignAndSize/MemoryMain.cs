using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Csharp.Samples.MemoryAssignAndSize
{
    /// <summary>
    /// 内存占用
    /// </summary>
    public class MemoryMain
    {
        /// <summary>
        /// 内存起始位置
        /// </summary>
        public static  long StartSize { get; set; }

        public static  long MemorySize { get; set; }
        public static  void Start()
        {
            StartSize = GC.GetTotalMemory(true);
        }

        public static long End()
        {
            GC.Collect();
            GC.WaitForFullGCComplete();
            long end = GC.GetTotalMemory(true);
            long useMemory = end - StartSize;
            MemorySize = useMemory;
            return useMemory;
        }

        public void Test()
        {
            long start = GC.GetTotalMemory(true);
            //计算代码
            GC.Collect();
            GC.WaitForFullGCComplete();
            long end = GC.GetTotalMemory(true);
            long useMemory = end - start;
        }
    }
}
