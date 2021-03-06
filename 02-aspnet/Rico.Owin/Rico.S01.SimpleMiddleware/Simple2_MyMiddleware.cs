﻿using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Rico.S01.SimpleMiddleware
{
    public class MyMiddleware1 : OwinMiddleware
    {
        /// <summary>
        /// 构造函数，第一个参数必须为 OwinMiddleware对象 ;第一个参数是固定的，后边还可以添加自定义的其它参数
        /// </summary>
        /// <param name="next">下一个中间件</param>
        public MyMiddleware1(OwinMiddleware next)
            : base(next)
        {

        }
        /// <summary>
        /// 处理用户请求的具体方法，该方法是必须的
        /// </summary>
        /// <param name="c">OwinContext对象</param>
        /// <returns></returns>
        public override Task Invoke(IOwinContext c)
        {
            if (Next != null && c.Request.Path.Value != "/home/index")
            {

                var message1 = "NotFound\r\n";
                var outbytes1 = Encoding.UTF8.GetBytes(message1);
                c.Response.ContentType = "text/html; charset=utf-8";
                c.Response.Write(outbytes1, 0, outbytes1.Length);
                return Next.Invoke(c);
            }

            // var urlPath = c.Request.Path;
            // switch (urlPath) { 
            //    ..........
            //    ..........
            //    可以根据不同的URL PATH调用不同的处理方法
            //    从而构成一个完整的应用。
            // }


            var message = "Welcome to My Home!";
            var outbytes = Encoding.UTF8.GetBytes(message);
            c.Response.ContentType = "text/html; charset=utf-8";
            c.Response.Write(outbytes, 0, outbytes.Length);

            return Task.FromResult<int>(0);
        }

    }

    /// <summary>
    ///  OWIN "中间件" - MyMiddleware2
    /// </summary>
    public class MyMiddleware2 : OwinMiddleware
    {


        /// <summary>
        /// 构造函数，第一个参数必须为 OwinMiddleware对象 ;第一个参数是固定的，后边还可以添加自定义的其它参数
        /// </summary>
        /// <param name="next">下一个中间件</param>
        public MyMiddleware2(OwinMiddleware next)
            : base(next)
        {
        }


        /// <summary>
        /// 处理用户请求的具体方法，该方法是必须的
        /// </summary>
        /// <param name="c">OwinContext对象</param>
        /// <returns></returns>
        public override Task Invoke(IOwinContext c)
        {

            if (Next != null && c.Request.Path.Value != "/user")
            {

                var message1 = "NotFound2!\r\n";
                var outbytes1 = Encoding.UTF8.GetBytes(message1);
                c.Response.ContentType = "text/html; charset=utf-8";
                c.Response.Write(outbytes1, 0, outbytes1.Length);
                return Task.FromResult(0);
            }

            // var urlPath = c.Request.Path;
            // switch (urlPath) { 
            //    ..........
            //    ..........
            //    可以根据不同的URL PATH调用不同的处理方法
            //    从而构成一个完整的应用。
            // }


            var message = "I'm MyMiddleware2";
            var outbytes = Encoding.UTF8.GetBytes(message);
            c.Response.ContentType = "text/html; charset=utf-8";
            c.Response.Write(outbytes, 0, outbytes.Length);

            return Task.FromResult<int>(0);
        }

    }
    /// <summary>
    /// 这个类是为AppBuilder添加一个名叫UseMyApp的扩展方法
    /// </summary>
    public static class MyExtension
    {
        public static IAppBuilder UseMyApp1(this IAppBuilder builder)
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