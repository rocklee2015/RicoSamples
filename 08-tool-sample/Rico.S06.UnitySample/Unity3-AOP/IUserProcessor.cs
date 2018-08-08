using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S06.UnitySample.Unity3_AOP
{
    [ExceptionHandlerAttribute(Order = 1)] //遗产处理
    [UserHandlerAttribute(Order = 2)] //注册校验
    [LogHandlerAttribute(Order = 3)]  //日志处理
    [CheckNameHandler(Order = 0)]  //日志处理
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
