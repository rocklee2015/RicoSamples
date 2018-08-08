using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Rico.S06.UnitySample.Unity3_AOP
{
    public class UserHandlerAttribute : HandlerAttribute  //注册校验
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            ICallHandler handler = new UserHandler() { Order = this.Order };
            return handler;
        }
    }

    public class LogHandlerAttribute : HandlerAttribute   //日志处理
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new LogHandler() { Order = this.Order };
        }
    }

    public class ExceptionHandlerAttribute : HandlerAttribute  //异常处理
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new ExceptionHandler() { Order = this.Order };
        }
    }
}
