using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.IOC.UnitySample.Unity1
{
    public class VipOrder : IOrder
    {
        public double Discount { get; set; }
        public void DumpDiscount()
        {
            Console.WriteLine("VipOrder：{0}", Discount);
        }
    }
}
