using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S13.ExceptionSample
{
    public class S01_没有丢失StackTrace
    {
        public void Excute()
        {
            try
            {
                // Call Method1  
                Console.WriteLine(Method1());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            Console.ReadLine();
        }
        public int Method1()
        {
            try
            {
                return Method1_1();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Method1_1()
        {
            int j = 0;
            return 10 / j;
        }
    }
}
