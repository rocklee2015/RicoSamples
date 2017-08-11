using Microsoft.Practices.Unity;

namespace Rico.S06.UnitySample.Unity1.DependencyInjection
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
        [OptionalDependency]
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
