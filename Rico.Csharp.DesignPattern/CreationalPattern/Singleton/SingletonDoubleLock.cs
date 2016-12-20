using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.Csharp.DesignPattern.CreationalPattern.Singleton
{
    /// <summary>
    /// 3.双重锁定 BadCode Do not Use
    /// </summary>
    public sealed class SingletonDoubleLock
    {
        static SingletonDoubleLock instance = null;
        static readonly object padlock = new object();

        SingletonDoubleLock()
        {
        }

        public static SingletonDoubleLock Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonDoubleLock();
                        }
                    }
                }
                return instance;
            }
        }

    }
}
