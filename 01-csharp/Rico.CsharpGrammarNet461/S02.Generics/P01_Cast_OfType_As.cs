using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.S01.Generic
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class Cast_OfType_As
    {
        /*
         * Cast : 将 System.Collections.IEnumerable 的元素强制转换为指定的类型。
         * 
         * OfType : 根据指定类型筛选 System.Collections.IEnumerable 的元素。
         */

        /// <summary>
        /// 
        /// https://msdn.microsoft.com/zh-cn/library/bb360913.aspx
        /// </summary>
        [TestMethod]
        public void Oftype_Demo()
        {
            ArrayList fruits = new ArrayList(4);
            fruits.Add("Mango");
            fruits.Add("Orange");
            fruits.Add("Apple");
            fruits.Add(3.0);
            fruits.Add("Banana");

            // Apply OfType() to the ArrayList.
            IEnumerable<string> queryString = fruits.OfType<string>();

            Assert.AreEqual(4, queryString.Count());

            IEnumerable<double> queryDouble = fruits.OfType<double>();

            Assert.AreEqual(1, queryDouble.Count());

            // The following query shows that the standard query operators such as 
            // Where() can be applied to the ArrayList type after calling OfType().
            IEnumerable<string> query2 =
                fruits.OfType<string>().Where(fruit => fruit.ToLower().Contains("n"));

            Console.WriteLine("\nThe following strings contain 'n':");

            Assert.AreEqual(3, query2.Count());

            foreach (string fruit in query2)
            {
                Console.WriteLine(fruit);
            } 
        }

    
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void Cast_ArrayList_ThrowException()
        {
            ArrayList fruits = new ArrayList(4);
            fruits.Add("Mango");
            fruits.Add("Orange");
            fruits.Add("Apple");
            fruits.Add(3);
            fruits.Add("Banana");

            IEnumerable<string> query1 = fruits.Cast<string>();

            Assert.AreEqual(4, query1.Count());

        }

        #region Cast
        /// <summary>
        /// cast 协变 成功
        /// </summary>
        [TestMethod]
        public void Cast_SonCovertToBase_Success()
        {
            var sons = new List<Son>()
            {
                new Son() { Name = "rico",Age = 25},
                new Son() { Name = "rock",Age = 24}
            };
            var fathers = sons.Cast<Father>().ToList();

            Assert.AreEqual(fathers.Count, 2);

            Assert.AreEqual(2, fathers.Count);

            Assert.AreEqual("rico", fathers.First().Name);
        }

        /// <summary>
        /// cast 逆变 invalidcast 异常
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void Cast_BaseCovertToSon_ThrowException()
        {
            var fathers = new List<Father>()
            {
                new Father() { Name = "rico",Age = 25},
                new Father() { Name = "rock",Age = 24}
            };
            var sons = fathers.Cast<Son>().ToList();

        }
        #endregion
       
        /// <summary>
        /// as 协变 成功
        /// </summary>
        [TestMethod]
        public void As_SonCovertToBase_Success()
        {
            var sons = new List<Son>()
            {
                new Son() { Name = "rico",Age = 25},
                new Son() { Name = "rock",Age = 24}
            };
            var fathers = sons.Select(a => a as Father).ToList();

            Assert.AreEqual(2, fathers.Count);

            Assert.AreEqual("rico", fathers.First().Name);
        }

        /// <summary>
        /// as 逆变 可以转换 但都是空值
        /// </summary>
        [TestMethod]
        public void As_BaseCovertToSon_Return_2Count_ButNull_NotThrowException()
        {
            var fathers = new List<Father>()
            {
                new Father() { Name = "rico",Age = 25},
                new Father() { Name = "rock",Age = 24}
            };
            var sons = fathers.Select(a => a as Son).ToList();

            Assert.IsNotNull(sons);

            Assert.AreEqual(sons.Count, 2);

            Assert.AreEqual(null, sons.FirstOrDefault());
        }


 
        /// <summary>
        /// oftype 协变 成功
        /// </summary>
        [TestMethod]
        public void OfType_SonCovertToBase_Success()
        {
            var sons = new List<Son>()
            {
                new Son() { Name = "rico",Age = 25},
                new Son() { Name = "rock",Age = 24}
            };

            var fathers = sons.OfType<Father>().ToList();

            Assert.AreEqual(fathers.Count, 2);
        }

        /// <summary>
        /// oftype 逆变 非空  数量为0 没有异常
        /// </summary>
        [TestMethod]
        public void OfType_BaseCovertToSon_Return_0_NotThrowException()
        {
            var fathers = new List<Father>()
            {
                new Father() { Name = "rico",Age = 25},
                new Father() { Name = "rock",Age = 24}
            };

            var sutdents = fathers.OfType<Son>().ToList();

            Assert.AreEqual(0,sutdents.Count);
        }
      
    }

    public class Father
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class Son : Father
    {
        public string School { get; set; }
    }
}
