using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.MSUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Test");
            Assert.IsTrue(true);
        }
    }
}
