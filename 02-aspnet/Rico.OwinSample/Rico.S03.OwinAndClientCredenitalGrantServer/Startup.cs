using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(Rico.S03.OwinOauthServer.Startup))]

namespace Rico.S03.OwinOauthServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var oAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new MyAuthorizationServerProvider(),
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
    }
}
