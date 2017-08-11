using Microsoft.Practices.Unity;

namespace Rico.S06.UnitySample.Unity2
{
    public class Unity2Main
    {
        public static void SimpleTest()
        {
            //创建容器  
            IUnityContainer container = new UnityContainer();
            //注册映射  
            container.RegisterType<IKiss, Boy>();
            //得到Boy的实例  
            var boy = container.Resolve<IKiss>();

            Lily lily = new Lily(boy);
            lily.Kiss();
        }
    }
}
