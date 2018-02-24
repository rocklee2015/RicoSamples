using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.MSUnitTest
{
    [TestClass]
    public class S03_CollectionAssert
    {
        [TestMethod]
        public void AreEqual()
        {
            var expected = new List<string>() { "abc" };
            var actual = new List<string>() { "abc" };
            CollectionAssert.AreEqual(expected,actual);
        }
    }
}
