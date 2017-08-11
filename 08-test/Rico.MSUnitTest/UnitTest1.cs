using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace Rico.MSUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string outputFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string dbFileName = Path.Combine(outputFolder, string.Format(@".\{0}.mdf", "Rico"));
            Console.WriteLine(dbFileName);
            Assert.IsTrue(true);
        }
    }
}
