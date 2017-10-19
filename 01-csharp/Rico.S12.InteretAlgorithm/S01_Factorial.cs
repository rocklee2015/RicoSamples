using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rico.S12.InteretAlgorithm
{
    /*
     * 使用委托实现阶乘
     * 
     */
    [TestClass]
    public class S01Factorial
    {
        /// <summary>
        /// 阶乘
        /// </summary>
        [TestMethod]
        public void Factorial()
        {
            //1*2*3*4*5
            Func<int, int> fib = null;
            fib = n => (n == 1) ? 1 : fib(n - 1) * n;

            var result = fib(5);
            Assert.AreEqual(result, 120);

            Console.WriteLine(result);
        }

        /// <summary>
        /// 阶乘 第二种实现
        /// </summary>
        [TestMethod]
        public void Factorial2()
        {
            var fib = Functional.Y<int, int>(h => m => (m == 1) ? 1 : h(m - 1) * m);
            var result = fib(5);

            Assert.AreEqual(result, 120);
        }

        /// <summary>
        /// 斐波那契
        /// </summary>
        [TestMethod]
        public void Fibonacci()
        {
            // 1,1,2,3,5,8,13,21
            Func<int, int> fib = null;
            fib = n => n > 1 ? fib(n - 1) + fib(n - 2) : n;

            var result = fib(6);
            Assert.AreEqual(8, result);

             result = fib(8);
            Assert.AreEqual(21, result);
            
        }



        [TestMethod]
        public void RecursionGetFiles()
        {
            var recGetFiles =
                    Functional.Y<string, IEnumerable<string>>
                    (f => d => Directory.GetFiles(d).Concat(Directory.GetDirectories(d).SelectMany(f)));

            foreach (var f in recGetFiles(Directory.GetCurrentDirectory()))
                Console.WriteLine(f);

        }
       

    }
    public class Functional
    {
        /// <summary>
        ///delegate  Func<A, R/>
        /// </summary>
        private delegate Func<A, R> Recursive<A, R>(Recursive<A, R> r);

        /// <summary>
        /// Ys the specified f.
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="f">The f.</param>
        /// <returns></returns>
        public static Func<A, R> Y<A, R>(Func<Func<A, R>, Func<A, R>> f)
        {
            Recursive<A, R> rec = r => a => f(r(r))(a);
            return rec(rec);
        }
    }
}


