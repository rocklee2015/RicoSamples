using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Rico.OwinWebApiOauth;
using Rico.S01.OwinWebApiOauth;

[assembly: OwinStartup(typeof(Startup))]

namespace Rico.S01.OwinWebApiOauth
{
    public class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            var oAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new CnBlogsAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };
            //基于.net 4.6 用以下
            //需要引用 nuget Microsoft.AspNet.Identity.Owin 
            app.UseOAuthBearerTokens(oAuthOptions);

            //基于.net 4.5 用以下(可是4.6 也可以啊)
            //app.UseOAuthAuthorizationServer(oAuthOptions);

            //app.UseOAuthAuthorizationServer(oAuthOptions);
            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //var configuration = new HttpConfiguration();

            //configuration.Routes.MapHttpRoute(name: "Default_WithAction",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional });
            //configuration.Routes.MapHttpRoute(name: "Default_WithoutAction",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional });
            //configuration.Routes.MapHttpRoute(name: "Default_Action",
            //    routeTemplate: "api/{controller}/{action}",
            //    defaults: new { id = RouteParameter.Optional });


            //app.UseWebApi(configuration);
        }
    }
}
