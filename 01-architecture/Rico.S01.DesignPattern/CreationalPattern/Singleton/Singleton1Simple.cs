namespace Rico.S01.DesignPattern.CreationalPattern.Singleton
{
    /// <summary>
    /// 1.单例模式简单实现
    /// </summary>
    public sealed class Singleton1Simple
    {
        static Singleton1Simple instance = null;

        Singleton1Simple()
        {
        }

        public static Singleton1Simple Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton1Simple();
                }
                return instance;
            }
        }

    }
}
