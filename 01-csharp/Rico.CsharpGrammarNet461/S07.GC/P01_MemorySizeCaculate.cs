using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S06.GCSample
{
    [TestClass]
    public class MemorySizeCaulateTest
    {
        [TestMethod]
        public void Caulate_MemorySize_Return_Value()
        {
            //计算执行该段代码需要多少内存
            long start = GC.GetTotalMemory(true);//

            //do something

            GC.Collect();
            GC.WaitForFullGCComplete();
            long end = GC.GetTotalMemory(true);
            long useMemory = end - start;

            Assert.IsTrue(useMemory > 0);
        }
    }
    public class MemorySizeCaculate
    {
        /// <summary>
        /// 内存起始位置
        /// </summary>
        public static long StartSize { get; set; }

        public static long MemorySize { get; set; }
        public static void Start()
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
