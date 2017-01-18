using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Baitu.UnitTest
{
    [TestClass]
    public class BaiTuTest
    {
        [TestMethod]
        public void AddDicTest()
        {
            var summation = new Dictionary<string, decimal>();
            AddDic(summation, "lee", (decimal)212.2);
            AddDic(summation, "lee", (decimal)122.2);
            AddDic(summation, "lee", (decimal)2.2);
            AddDic(summation, "rico", (decimal)2.2);
            foreach (var dic in summation)
            {
                Console.WriteLine($"{dic.Key}:{dic.Value}");
            }
        }
        [TestMethod]
        public void ExceptTest_ReturnIsFalse()
        {
            List<string> a = new List<string>();
            List<string> b = new List<string>();
            a.Add("A1");
            a.Add("A2");
            a.Add("B1");

            b.Add("A1");
            b.Add("A2");
            //b.Add("B3");
            var c = b.Except(a);
            foreach (var s in c)
            {
                Console.WriteLine(s);
            }
            Assert.IsFalse(b.Except(a).Any());


        }
        [TestMethod]
        public void ExceptTest_ReturnIsTrue()
        {
            List<string> a = new List<string>();
            List<string> b = new List<string>();
            a.Add("A1");
            a.Add("A2");
            a.Add("B1");

            b.Add("B2");
            //b.Add("B3");
            var c = b.Except(a);
            foreach (var s in c)
            {
                Console.WriteLine(s);
            }
            Assert.IsTrue(b.Except(a).Any());
        }

        [TestMethod]
        public void String_Test()
        {
            List<string> a = new List<string>();
            a.Add("30001001");
            a.Add("30001000");
            a.Add("331121");

            //a.ForEach(x => { x = "100"; });
            //var result = string.Join(",",a);
            var result = a.Aggregate((x, y) => x + "," + $"'{y}'");
            Console.WriteLine(result);
            Assert.IsTrue(true);
        }

        private void AddDic(Dictionary<string, decimal> source, string key, decimal value)
        {
            if (source.ContainsKey(key))
            {
                source[key] += value;
            }
            else
            {
                source.Add(key, value);
            }
        }
    }
}
