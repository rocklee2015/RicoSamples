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
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            #region token
            //token-form
            var basicOption = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token-basic"),
                Provider = new BasicCredntialAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };

            //基于.net 4.6 用以下
            //需要引用 nuget Microsoft.AspNet.Identity.Owin 
            app.UseOAuthBearerTokens(basicOption);

            //token-form
            var formOption = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token-form"),
                Provider = new FormCredentialAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };

            //基于.net 4.6 用以下
            //需要引用 nuget Microsoft.AspNet.Identity.Owin 
            app.UseOAuthBearerTokens(formOption);

            //
            var refreshOption = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token-refresh"),
                Provider = new RefreshTokenAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true,
                RefreshTokenProvider = new RicoRefreshTokenProvider()
            };

            app.UseOAuthBearerTokens(refreshOption);
            #endregion

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

            #region  PersintendRefreshToken
            // DependencyInjectionConfig.Register();
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IRefreshTokenService, RefreshTokenService>();

            container.RegisterType<IRefreshTokenRepository, RefreshTokenRepository>();

            container.RegisterType<IClientService, ClientService>();

            container.RegisterType<IClientRepository, ClientRepository>();

            var refreshOption2 = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token-refresh2"),
                Provider = container.Resolve<PersistendRefreshTokenAuthorizationServerProvider>(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true,
                RefreshTokenProvider = container.Resolve<PersistendRefreshTokenProvider>()
            };

            app.UseOAuthBearerTokens(refreshOption2);
            #endregion
            app.Run(async context => await context.Response.WriteAsync("Hello World  我是 OwinOauth 服务器! "));
        }
    }
}
