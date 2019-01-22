using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.CsharpGrammarNet461.S12.InteretAlgorithm
{
    public static class P02_Money
    {
        public static void Mains()
        {
            //第一步
            int n = 10;
            int total = 13;
            int tmp = total;
            int[] arr = new int[n+1];
            for (int i = 0; i <=n; i++)
            {
                arr[i] = (int)Math.Pow(2, n - i);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (tmp / arr[i] != 0)
                    Console.WriteLine($"{arr[i]}:{tmp / arr[i]}个");
                tmp = tmp % arr[i];
            }
            if (tmp!=0) {
                Console.WriteLine("无结果");
            }
            Console.ReadKey();
        }
    }
}
