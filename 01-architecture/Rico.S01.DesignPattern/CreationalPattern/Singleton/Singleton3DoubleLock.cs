namespace Rico.S01.DesignPattern.CreationalPattern.Singleton
{
    /// <summary>
    /// 3.双重锁定 BadCode Do not Use
    /// </summary>
    public sealed class Singleton3DoubleLock
    {
        static Singleton3DoubleLock instance = null;
        static readonly object padlock = new object();

        Singleton3DoubleLock()
        {
        }

        public static Singleton3DoubleLock Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton3DoubleLock();
                        }
                    }
                }
                return instance;
            }
        }

    }
}
