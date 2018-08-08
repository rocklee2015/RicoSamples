using Microsoft.Practices.Unity.InterceptionExtension;
using System;

namespace Rico.S06.UnitySample.Unity3_AOP
{
    public class UserHandler : ICallHandler  //注册校验的行为
    {
        public int Order { get; set; }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            User user = input.Inputs[0] as User;
            if (user.Password.Length < 10)
            {
                return input.CreateExceptionMethodReturn(new Exception("密码长度不能小于10位"));
            }
            Console.WriteLine("参数检测无误");

            IMethodReturn methodReturn = getNext.Invoke().Invoke(input, getNext);

            return methodReturn;
        }
    }

    public class LogHandler : ICallHandler    //日志处理的行为
    {
        public int Order { get; set; }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            User user = input.Inputs[0] as User;
            string message = string.Format("RegUser:Username:{0},Password:{1}", user.UserName, user.Password);
            Console.WriteLine("日志已记录，Message:{0},Ctime:{1}", message, DateTime.Now);
            return getNext()(input, getNext);
        }
    }


    public class ExceptionHandler : ICallHandler   //异常处理的行为
    {
        public int Order { get; set; }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            IMethodReturn methodReturn = getNext()(input, getNext);
            if (methodReturn.Exception == null)
            {
                Console.WriteLine("无异常");
            }
            else
            {
                Console.WriteLine("异常:{0}", methodReturn.Exception.Message);
            }
            return methodReturn;
        }
    }
}
