using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace Rico.S03.OwinOauthWeb.Sericies
{
    public class DependencyInjectionConfig
    {
        public static void Register()
        {
            IUnityContainer container = new UnityContainer();
            //var containter = IocContainer.Default;// = new IUnityContainer();
            container.RegisterType<IRefreshTokenService, RefreshTokenService>();
           
            container.RegisterType<IRefreshTokenRepository, RefreshTokenRepository>();

            container.RegisterType<IClientService, ClientService>();

            container.RegisterType<IClientRepository, ClientRepository>();
        }
    }
}