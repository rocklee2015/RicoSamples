namespace Rico.S06.UnitySample.Unity1.DependencyInjection
{
    /// <summary>
    /// 单构造器注入
    /// </summary>
    public class SingleConstructor : IOrderWithLogging
    {
        private IOrder order;
        private ILogger logger;

        public SingleConstructor(IOrder order, ILogger logger)
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
