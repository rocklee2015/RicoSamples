using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.IOC.UnitySample.Unity1
{
    public class CommonOrder:IOrder
    {
        public double Discount { get; set; }
        public void DumpDiscount()
        {
            Console.WriteLine("CommonOrder：{0}",Discount);
        }
    }
}
