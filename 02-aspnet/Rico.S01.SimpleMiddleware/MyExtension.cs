using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rico.S01.SimpleMiddleware
{
    /// <summary>
    /// 这个类是为AppBuilder添加一个名叫UseMyApp的扩展方法
    /// </summary>
    public static class MyExtension
    {
        public static IAppBuilder UseMyApp(this IAppBuilder builder)
        {
            return builder.Use<MyMiddleware1>();
            //UseXXX可以带多个参数，对应中间件构造函数中的第2、3、....参数;
        }
        public static IAppBuilder UseMyApp2(this IAppBuilder builder)
        {
            return builder.Use<MyMiddleware2>();
            //UseXXX可以带多个参数，对应中间件构造函数中的第2、3、....参数;
        }
    }
}