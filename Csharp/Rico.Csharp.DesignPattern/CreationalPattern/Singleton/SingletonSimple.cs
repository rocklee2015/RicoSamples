using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Csharp.DesignPattern.CreationalPattern.Singleton
{
    /// <summary>
    /// 1.单例模式简单实现
    /// </summary>
    public sealed class SingletonSimple
    {
        static SingletonSimple instance = null;

        SingletonSimple()
        {
        }

        public static SingletonSimple Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonSimple();
                }
                return instance;
            }
        }

    }
}
