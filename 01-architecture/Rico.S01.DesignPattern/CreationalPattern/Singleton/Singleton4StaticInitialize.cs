namespace Rico.S01.DesignPattern.CreationalPattern.Singleton
{
    /// <summary>
    /// 4.静态初始化
    /// </summary>
    public sealed class Singleton4StaticInitialize
    {
        static readonly Singleton4StaticInitialize instance = new Singleton4StaticInitialize();

        static Singleton4StaticInitialize()
        {
        }

        Singleton4StaticInitialize()
        {
        }

        public static Singleton4StaticInitialize Instance
        {
            get
            {
                return instance;
            }
        }

    }
}
