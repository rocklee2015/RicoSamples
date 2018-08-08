using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Rico.S06.UnitySample.Unity3_AOP
{
    public class Unity3Main
    {
        public static void SimpleTest()
        {
            //声明一个容器
            IUnityContainer container = new UnityContainer();

            //声明UnityContainer并注册IUserProcessor
            container.RegisterType<IUserProcessor, UserProcessor>();

            container.AddNewExtension<Interception>().Configure<Interception>()
                .SetInterceptorFor<IUserProcessor>(new InterfaceInterceptor());

            
            IUserProcessor userprocessor = container.Resolve<IUserProcessor>();

            var user = new User() {  UserName="ricolee",Password="asdf132432432432"};
            userprocessor.RegUser(user); //调用注册方法。
        }
    }
}
