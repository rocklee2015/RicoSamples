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
        public void ConfigS01(IAppBuilder app)
        {
            //token-form
            var option = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token-s01"),
                Provider = new FormCredentialAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };

            //基于.net 4.6 用以下
            //需要引用 nuget Microsoft.AspNet.Identity.Owin 
            app.UseOAuthBearerTokens(option);
        }
    }
}