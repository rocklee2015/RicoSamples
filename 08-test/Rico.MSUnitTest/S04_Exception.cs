using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.MSUnitTest
{
    [TestClass]
    public class S04_Exception
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ThrowException()
        {
            throw new Exception();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "HasException2")]
        public void ThrowExceptionWithMessage()
        {
            throw new Exception("HasException");
        }
    }
}
