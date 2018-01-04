using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Rico.S03.OwinOauthWeb.Startup))]

namespace Rico.S03.OwinOauthWeb
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var oAuthOptions = new OAuthAuthorizationServerOptions
            //{
            //    TokenEndpointPath = new PathString("/token"),
            //    Provider = new MyAuthorizationServerProvider(),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
            //    AllowInsecureHttp = true
            //};
            ////基于.net 4.6 用以下
            ////需要引用 nuget Microsoft.AspNet.Identity.Owin 
            //app.UseOAuthBearerTokens(oAuthOptions);

            app.Run(async context => await context.Response.WriteAsync("Hello World  Simple2 ! "));
        }
    }
}
