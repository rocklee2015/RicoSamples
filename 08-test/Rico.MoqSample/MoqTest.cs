using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Rico.MoqSample
{
    /// <summary>
    /// http://www.cnblogs.com/gossip/archive/2012/05/16/2503477.html
    /// </summary>
    [TestClass]
    public class MoqTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var customer = new Mock<ICustomer>(); //建立Mock对象

            //设置mock调用行为

            //customer.Setup(p => p.AddCall());

            customer.Setup(p => p.GetCall()).Returns("phone:89898789");

            customer.Setup(p => p.GetCall("Tom")).Returns("Hello");

            //使用mock调用方法

            //customer.Object.AddCall();

            Assert.AreEqual("phone:89898789", customer.Object.GetCall());

            Assert.AreEqual("Hello", customer.Object.GetCall("Tom"));

        }

        [TestMethod]
        public void TestMoqRef()
        {
            var customer = new Mock<ICustomer>();

            var outString = "oo";

            customer.Setup(p => p.GetAddress("lk", out outString)).Returns("hangzhou");

            customer.Setup(p => p.GetFamilyCall(ref outString)).Returns("139");

            var address = "shanghai";
            //只有 第一个参数为'lk', 才能
            var result = customer.Object.GetAddress("lk", out address);
            Assert.AreEqual("hangzhou", result);
            Assert.AreEqual(outString, address);

            //参数值不是 oo 都得不到返回值是139
            var result2 = customer.Object.GetFamilyCall(ref outString);
            Assert.AreEqual("139", result2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestMoqException()
        {
            var customer = new Mock<ICustomer>();

            //参数为1时抛出异常
            customer.Setup(p => p.ShowException("1"))

                .Throws(new ArgumentNullException());

            customer.Object.ShowException("1");

        }

        [TestMethod]
        public void Test3()
        {
            var customer = new Mock<ICustomer>();

            int iCount = 0;

            customer.Setup(p => p.AddCall()).Callback(() => iCount++);

            Assert.AreEqual(0, iCount);

            customer.Object.AddCall();

            Assert.AreEqual(1, iCount);

            customer.Object.AddCall();

            Assert.AreEqual(2, iCount);

            customer.Object.AddCall();

            Assert.AreEqual(3, iCount);

        }

        [TestMethod]
        public void Test4()
        {
            var customer = new Mock<ICustomer>();
            // customer.Setup(x => x.SelfMatch(It.Is<int>(i => i % 2 == 0))).Returns("1");
        }

        [TestMethod]
        public void Test5()
        {
            var customer = new Mock<Customer>();

            //第一种
            customer.Setup(p => p.Name).Returns("Tom");
            Assert.AreEqual("Tom", customer.Object.Name);

            //第二种
            customer.SetupProperty(p => p.Name, "tt");
            Assert.AreEqual("tt", customer.Object.Name);
        }

        [TestMethod]
        public void TestVerify()

        {

            var customer = new Mock<ICustomer>();

            customer.Setup(p => p.GetCall(It.IsAny<string>()))

                .Returns("方法调用")

                .Callback((string s) => Console.WriteLine("ok" + s))

                .Verifiable();

            customer.Object.GetCall("调用了！");

            customer.Verify();



        }

        

      
    }

}

