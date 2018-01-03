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
            app.UseMyApp();

            app.UseMyApp2();

            app.Run(async context => await context.Response.WriteAsync("Hello World!"));

        }
    }
}
