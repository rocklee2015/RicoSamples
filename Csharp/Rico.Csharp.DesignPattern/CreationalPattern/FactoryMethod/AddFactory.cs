using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rico.Csharp.DesignPattern.CreationalPattern.SimpleFactory;

namespace Rico.Csharp.DesignPattern.CreationalPattern.FactoryMethod
{
    /// <summary>
    /// 专门负责生产“+”的工厂
    /// </summary>
    class AddFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationAdd();
        }
    }
}
