using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Csharp.DesignPattern.CreationalPattern.Singleton
{
    /// <summary>
    /// 4.静态初始化
    /// </summary>
    public sealed class SingletonStaticInitialize
    {
        static readonly SingletonStaticInitialize instance = new SingletonStaticInitialize();

        static SingletonStaticInitialize()
        {
        }

        SingletonStaticInitialize()
        {
        }

        public static SingletonStaticInitialize Instance
        {
            get
            {
                return instance;
            }
        }

    }
}
