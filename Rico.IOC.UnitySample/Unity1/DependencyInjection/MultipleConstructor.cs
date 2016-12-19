using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Rico.IOC.UnitySample.Unity1
{
    public class MultipleConstructor:IOrderWithLogging
    {
        private IOrder order;
        private ILogger logger;

        public MultipleConstructor()
        {

        }
        //无需此特性，Unity会自动选择参数较多的构造器
        [InjectionConstructor]
        public MultipleConstructor(IOrder order, ILogger logger)
        {
            this.order = order;
            this.logger = logger;
        }

        public void Output()
        {
            order.DumpDiscount();
            logger.Log($"{order.Discount}");
        }
    }
}
