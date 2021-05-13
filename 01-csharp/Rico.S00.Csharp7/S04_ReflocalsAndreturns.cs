using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S00.Csharp7
{
    [TestClass]
    public class S04_ReflocalsAndreturns
    {
        [TestMethod]
        public void Test()
        {
            int[,] arr = { { 10, 15 }, { 20, 25 } };
            ref var num = ref GetLocalRef(arr, c => c == 20);
            num = 600;

            Console.WriteLine(arr[1, 0]);
        }
        static ref int GetLocalRef(int[,] arr, Func<int, bool> func)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (func(arr[i, j]))
                    {
                        return ref arr[i, j];
                    }
                }
            }

            throw new InvalidOperationException("Not found");
        }
    }
}
