using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S00.Csharp5
{
    [TestClass]
    public class ConditionCompileTest
    {
        [TestMethod]
        public void Condition_If_ElseIf() {
            var condition = 1;
#if DEBUG
            condition=2;
#else 
            condition=3;
#endif
            Console.WriteLine(condition);
        }
    }
}
