using System;

namespace Rico.S06.UnitySample.Unity1
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
