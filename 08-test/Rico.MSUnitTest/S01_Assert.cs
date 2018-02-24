using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection;

namespace Rico.MSUnitTest
{
    [TestClass]
    public class S01_Assert
    {

        public void AssertStaticMethod()
        {
            //Assert 的静态方法 17 个
            //Assert.AreEqual(2.1,2.1);
            //Assert.AreEqual<>();
            //Assert.AreNotEqual();
            //Assert.AreNotEqual<>();
            //Assert.AreNotSame();
            //Assert.AreSame();
            //Assert.Equals();
            //Assert.Fail();
            //Assert.Inconclusive();
            //Assert.IsFalse();
            //Assert.IsInstanceOfType();
            //Assert.IsNotInstanceOfType();
            //Assert.IsNotNull();
            //Assert.IsNull();
            //Assert.IsTrue();
            //Assert.ReferenceEquals();
            //Assert.ReplaceNullChars();

        }

        [TestMethod]
        public void AreEqual()
        {
            object obj1, obj2;
            obj1 = 2;
            obj2 = 2;

            Assert.AreEqual(2.1F, 2.1F);
            Assert.AreEqual(2.1D, 2.1D);
            Assert.AreEqual(obj1, obj2);

            Assert.AreEqual(2, 2);
            Assert.AreEqual("test", "test");

            Assert.AreEqual("test", "test", "测试结果不对");
            Assert.AreEqual("test", "test", "测试结果不对", "");
        }

        [TestMethod]
        public void AreNotEqual()
        {
            Assert.AreNotEqual(2.1F, 2.2F);
        }

        [TestMethod]
        public void AreNotSame()
        {
            //Assert.AreNotSame(2.2, 2.2);//转换为 Object 的值将永远不会相等
            Assert.AreNotSame("test", "testNew");
        }

        [TestMethod]
        public void AreSame()
        {
            //Assert.AreSame(2.2, 2.2);//转换为 Object 的值将永远不会相等
            Assert.AreSame("test", "test");
        }

        [TestMethod()]
        public void Equals()
        {
            //Assert.Equals("test","test");//Equlas 不应用于断言
            Assert.Inconclusive();
        }
        [TestMethod]
        public void Fail()
        {
            Assert.Fail("test");
        }

        [TestMethod]
        public void Inconclusive()
        {
            Assert.Inconclusive("跳过");
        }

        [TestMethod]
        public void IsFalse()
        {
            Assert.IsFalse(1 == 2);
        }

        [TestMethod]
        public void IsInstanceOfType()
        {
            var val = "test";
            Type valType = typeof(string);
            Assert.IsInstanceOfType(val, valType);
        }
        [TestMethod]
        public void IsNotInstanceOfType()
        {
            var val = "test";
            Type valType = typeof(int);
            Assert.IsNotInstanceOfType(val, valType);
        }
        [TestMethod]
        public void IsNotNull()
        {
            var val = "test";
            Assert.IsNotNull(val);
        }
        [TestMethod]
        public void IsNull()
        {
            var val = "test";
            val = null;
            Assert.IsNull(val);
        }
        [TestMethod]
        public void IsTrue()
        {
            Assert.IsTrue(2 == 2);
        }
        [TestMethod]
        public void ReferenceEquals()
        {
            var val1 = "test";
            var val2 = "test";
            Assert.ReferenceEquals(val1, val2);
        }
        [TestMethod]
        public void ReplaceNullChars()
        {
            var val = "test hello  world";
            var result = Assert.ReplaceNullChars(val);
            Console.WriteLine(result);
        }


    }
}
