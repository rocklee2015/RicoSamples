using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Rico.S03.ConfigConst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S03.OwinOauthWeb
{
    public class FormCredentialAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// 验证客户端的证明
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
        
            //从正文获取
            context.TryGetFormCredentials(out clientId, out clientSecret);

            if (clientId == RicoOauth.clientId && clientSecret ==RicoOauth.clientSecret)
            {
                context.Validated(clientId);
            }

            return base.ValidateClientAuthentication(context);
        }

        /// <summary>
        /// 授权客户端凭证
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, "iOS App"));
            var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
            context.Validated(ticket);

            return base.GrantClientCredentials(context);
        }
    }
}
