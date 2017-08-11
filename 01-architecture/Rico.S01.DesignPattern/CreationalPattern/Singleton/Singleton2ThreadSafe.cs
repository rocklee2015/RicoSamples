namespace Rico.S01.DesignPattern.CreationalPattern.Singleton
{
    /// <summary>
    /// 2.线程安全-单例模式
    /// </summary>
    public sealed class Singleton2ThreadSafe
    {
        static Singleton2ThreadSafe instance = null;
        static readonly object padlock = new object();

        Singleton2ThreadSafe()
        {
        }

        public static Singleton2ThreadSafe Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton2ThreadSafe();
                    }
                    return instance;
                }
            }
        }

    }
}
