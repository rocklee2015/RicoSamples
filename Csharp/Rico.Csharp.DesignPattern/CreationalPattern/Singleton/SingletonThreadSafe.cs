using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Csharp.DesignPattern.CreationalPattern.Singleton
{
    /// <summary>
    /// 2.线程安全-单例模式
    /// </summary>
    public sealed class SingletonThreadSafe
    {
        static SingletonThreadSafe instance = null;
        static readonly object padlock = new object();

        SingletonThreadSafe()
        {
        }

        public static SingletonThreadSafe Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonThreadSafe();
                    }
                    return instance;
                }
            }
        }

    }
}
