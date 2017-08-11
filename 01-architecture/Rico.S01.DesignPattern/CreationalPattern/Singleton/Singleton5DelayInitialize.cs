namespace Rico.S01.DesignPattern.CreationalPattern.Singleton
{
    /// <summary>
    /// 5.延迟初始化
    /// </summary>
    public sealed class Singleton5DelayInitialize
    {
        Singleton5DelayInitialize()
        {
        }

        public static Singleton5DelayInitialize Instance
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

            internal static readonly Singleton5DelayInitialize instance = new Singleton5DelayInitialize();
        }

    }
}
