using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using Rico.Utiliy.ServiceStackRedis;

namespace Rico.ServiceStackUnitTest
{
    [TestClass]
    public class SerivceStackUnitTest
    {
        [TestInitialize]
        public void Intialize()
        {
            System.Diagnostics.Process.Start(@"E:\rico-demo\Redis\redis-2.4.5-win32-win64\64bit\redis-server.exe");//此处为Redis的存储路径
        }

        [TestMethod]
        public void StoreAllTest()
        {
           
        }
    }
}
