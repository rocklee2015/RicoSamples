using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Csharp.DesignPattern.CreationalPattern.Singleton
{
    /// <summary>
    /// 5.延迟初始化
    /// </summary>
    public sealed class SingletonDelayInitialize
    {
        SingletonDelayInitialize()
        {
        }

        public static SingletonDelayInitialize Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        class Nested
        {
            static Nested()
            {
            }

            internal static readonly SingletonDelayInitialize instance = new SingletonDelayInitialize();
        }

    }
}
