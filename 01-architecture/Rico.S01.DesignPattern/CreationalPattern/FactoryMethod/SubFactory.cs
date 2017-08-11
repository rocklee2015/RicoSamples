using Rico.S01.DesignPattern.CreationalPattern.SimpleFactory;

namespace Rico.S01.DesignPattern.CreationalPattern.FactoryMethod
{
    /// <summary>
    /// 专门负责生产“-”的工厂
    /// </summary>
    class SubFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationSub();
        }
    }
}
