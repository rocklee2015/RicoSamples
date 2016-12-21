using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rico.Csharp.DesignPattern.CreationalPattern.SimpleFactory;

namespace Rico.Csharp.DesignPattern.CreationalPattern.FactoryMethod
{
    /// <summary>
    /// 工厂方法
    /// </summary>
    interface IFactory
    {
        Operation CreateOperation();
    }
}
