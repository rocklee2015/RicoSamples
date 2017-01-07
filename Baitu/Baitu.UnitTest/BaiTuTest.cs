using System;
using System.Collections.Generic;
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
            AddDic(summation,"lee",(decimal)212.2);
            AddDic(summation, "lee", (decimal)122.2);
            AddDic(summation, "lee", (decimal)2.2);
            AddDic(summation, "rico", (decimal)2.2);
            foreach (var dic in summation)
            {
                Console.WriteLine($"{dic.Key}:{dic.Value}");
            }
        }

        private void AddDic(Dictionary<string, decimal> source,string key,decimal value)
        {
            if (source.ContainsKey(key))
            {
                source[key] += value;
            }
            else
            {
                source.Add(key,value);
            }
        }
    }
}
