using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rico.S00.Csharp6
{
    [TestClass]
    public class ConditionCompileTest
    {
        [TestMethod]
        public void Condition_If_ElseIf()
        {
            var condition = 1;
#if DEBUG
            condition = 2;
#else
            condition=3;
#endif

#if DEBUG
            Assert.IsTrue(condition == 2);
#else 
             Assert.IsTrue(condition == 3);
#endif
        }
    }
}
