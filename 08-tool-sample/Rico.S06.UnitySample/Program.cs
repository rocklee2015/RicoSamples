using Rico.S06.UnitySample.Unity3_AOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S06.UnitySample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Unity3Main.SimpleTest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

            Console.Read();
        }
    }
}
