using Rico.S01.DesignPattern.CreationalPattern.SimpleFactory;

namespace Rico.S01.DesignPattern.CreationalPattern.FactoryMethod
{
    /// <summary>
    /// 工厂方法
    /// </summary>
    interface IFactory
    {
        Operation CreateOperation();
    }
}
