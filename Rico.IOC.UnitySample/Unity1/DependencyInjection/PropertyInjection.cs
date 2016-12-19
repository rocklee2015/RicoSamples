using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Rico.IOC.UnitySample.Unity1
{
    public class PropertyInjection : IOrderWithLogging
    {
        private IOrder order;
        private ILogger logger;
        [Dependency]
        public IOrder Order
        {
            get
            {
                return order;
            }

            set
            {
                order = value;
            }
        }
        [Dependency]
        public ILogger Logger
        {
            get
            {
                return logger;
            }

            set
            {
                logger = value;
            }
        }

        public void Output()
        {
            order.DumpDiscount();
            logger.Log($"{order.Discount}");
        }
    }
}
