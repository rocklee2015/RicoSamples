using System;

namespace Rico.S06.UnitySample.Unity1
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
