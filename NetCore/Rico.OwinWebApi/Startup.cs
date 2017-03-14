using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Rico.OwinWebApi.Startup))]

namespace Rico.OwinWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();

            configuration.Routes.MapHttpRoute(name: "Default_WithAction",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
            configuration.Routes.MapHttpRoute(name: "Default_WithoutAction",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            configuration.Routes.MapHttpRoute(name: "Default_Action",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional });


            app.UseWebApi(configuration);
        }
    }
}
