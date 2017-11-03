using Rico.XunitTest.CodeSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rico.XunitTest
{

    public class FibonacciTest
    {
        [Fact]
        public void GetFibonacciValue_Return_Ture()
        {
            //1,1,2,3,5
            var fib = new Fibonacci();
            var result = fib.GetFibonacciValue(5);
            Assert.Equal(5, result);
        }
        [Fact]
        public void GetFibonacciValue_Return_False()
        {
            //1,1,2,3,5,8
            var fib = new Fibonacci();
            var result = fib.GetFibonacciValue(6);
            Assert.NotEqual(6,result);
        }
    }
}
