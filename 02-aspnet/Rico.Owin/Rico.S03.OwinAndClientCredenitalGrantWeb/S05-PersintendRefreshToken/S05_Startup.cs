using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Rico.S03.OwinOauthWeb.Sericies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace Rico.S03.OwinOauthWeb
{
    public partial class Startup
    {
        public void ConfigS05(IAppBuilder app)
        {
            // DependencyInjectionConfig.Register();
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IRefreshTokenService, RefreshTokenService>();

            container.RegisterType<IRefreshTokenRepository, RefreshTokenRepository>();

            container.RegisterType<IClientService, ClientService>();

            container.RegisterType<IClientRepository, ClientRepository>();

            var option = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token-s05"),
                Provider = container.Resolve<PersistendRefreshTokenAuthorizationServerProvider>(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true,
                RefreshTokenProvider = container.Resolve<PersistendRefreshTokenProvider>()
            };

            app.UseOAuthBearerTokens(option);
        }
    }
}