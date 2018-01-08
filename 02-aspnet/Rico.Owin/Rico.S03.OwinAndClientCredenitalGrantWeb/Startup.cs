using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Rico.S03.OwinOauthWeb.Sericies;
using Unity;

[assembly: OwinStartup(typeof(Rico.S03.OwinOauthWeb.Startup))]

namespace Rico.S03.OwinOauthWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigS01(app);

            ConfigS02(app);

            ConfigS03(app);

            ConfigS04(app);

            ConfigS05(app);

            #region Simple 2  WEB API

            /*
             * 需要安装 Microsoft.AspNet.WebApi.OwinSelfHost
             */
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",//其中action指的就是方法名,这种方式可以直接按http://localhost:9000/api/valuesparam/getproduct的方式访问  
                defaults: new { id = RouteParameter.Optional }//Optional表明routeTemplate中的id是可选的  
            );
            app.UseWebApi(config);

            #endregion

            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello World  我是 OwinOauthServer 服务器! ");
            });
        }
    }
}
