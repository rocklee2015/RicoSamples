using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S06.UnitySample.Unity3_AOP
{
    [UserHandlerAttribute(Order = 1)] //注册校验
    [LogHandlerAttribute(Order = 2)]  //日志处理
    [ExceptionHandlerAttribute(Order = 3)] //遗产处理
    public interface IUserProcessor
    {
        void RegUser(User user);
    }

    public class UserProcessor : IUserProcessor//MarshalByRefObject,
    {
        public void RegUser(User user)
        {
            Console.WriteLine("注册。");
        }
    }
    public class User
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
