using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Rico.S01.SimpleMiddleware.Startup))]

namespace Rico.S01.SimpleMiddleware
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            //simple 1  简单的owin中间件
            //app.Run(context =>
            //{
            //    context.Response.ContentType = "text/plain";
            //    return context.Response.WriteAsync("Hello, world.");
            //});

            //simple 2 自定义owin中间件
            //app.UseLYMMiddleware();
            //app.Run(async context => await context.Response.WriteAsync("Hello World  Simple2 ! "));

            //simple 3
            //app.UseMyApp1();
            //app.UseMyApp2();
            //app.Run(async context => await context.Response.WriteAsync("Simple3 ! "));

            //simple 4
            app.UseLoggerMiddleware(new LoggerMiddlewareParameters() {  siteName="rico.demo"});
            app.Run(async context => await context.Response.WriteAsync("Hello World  Simple2 ! "));
        }
    }
}
