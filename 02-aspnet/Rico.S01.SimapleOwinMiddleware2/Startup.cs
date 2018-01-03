using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Rico.S01.SimapleOwinMiddleware2.Startup))]
namespace Rico.S01.SimapleOwinMiddleware2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseLYMMiddleware();
            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return  context.Response.WriteAsync("Hello, world.");
            });

        }
    }
}
