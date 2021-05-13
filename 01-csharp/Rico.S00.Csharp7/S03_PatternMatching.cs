using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S00.Csharp7
{

    [TestClass]
    public class S03_PatternMatching
    {
        [TestMethod]
        public void PatternMatching_Test()
        {
            List<object> nums = new List<object>();
            short a = 1;
            nums.Add(a);
            int b = 2;
            nums.Add(b);
            string c = "3";
            nums.Add(c);
            Console.WriteLine(GetSum(nums));
        }

        static int GetSum(IEnumerable<object> values)
        {
            //原理解析：此 is 非彼 is ，这个扩展的 is 其实是 as 和 if 的组合。即它先进行 as 转换再进行 if 判断，判断其结果是否为 null，不等于 null 则执行
            //语句块逻辑，反之不行。由上可知其实C# 7之前我们也可实现类似的功能，只是写法上比较繁琐。
            var sum = 0;
            if (values == null) return sum;

            foreach (var item in values)
            {
                if (item is short)     // C# 7 之前的 is expressions
                {
                    sum += (short)item;
                }
                else if (item is int val)  // C# 7 的 is expressions
                {
                    sum += val;
                }
                else if (item is string str && int.TryParse(str, out var result))  // is expressions 和 out variables 结合使用
                {
                    sum += result;
                }
                else if (item is IEnumerable<object> subList)
                {
                    sum += GetSum(subList);
                }
            }

            return sum;
        }
    }
}
