using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rico.S03.OwinOauthWeb
{
    public partial class Startup
    {
        public void ConfigS04(IAppBuilder app)
        {
            //token-basic
            var option = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token-s04"),
                Provider = new RefreshTokenAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true,
                RefreshTokenProvider = new RicoRefreshTokenProvider()
            };

            //基于.net 4.6 用以下
            //需要引用 nuget Microsoft.AspNet.Identity.Owin 
            app.UseOAuthBearerTokens(option);
        }
    }
}