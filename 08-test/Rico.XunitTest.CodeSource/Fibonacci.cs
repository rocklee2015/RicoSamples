using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.XunitTest.CodeSource
{
    public class Fibonacci
    {


        public int GetFibonacciValue(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            int first = 1;
            int second = 1;
            for (int i = 2; i < n; i++)
            {
                var temp = second;
                second += first;
                first = temp;
            }
            return second;

        }
    }
}
