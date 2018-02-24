using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.MSUnitTest
{
    [TestClass]
    public class S02_StringAssert
    {

        [TestMethod]
        public void Contains()
        {
            StringAssert.Contains("abc d tefs","te");
        }
        [TestMethod]
        public void StartsWith()
        {
            StringAssert.Contains("abc d tefs", "abc");
        }
        [TestMethod]
        public void EndsWith()
        {
            StringAssert.Contains("abc d tefs", "fs");
        }
        [TestMethod]
        public void Matches()
        {
            StringAssert.Contains("abc d tefs", "te");
        }
    }
}
