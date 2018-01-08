using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Rico.S03.OwinOauthWeb.Sericies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Rico.S03.OwinOauthWeb
{
    public class PersistendRefreshTokenAuthorizationServerProvider: OAuthAuthorizationServerProvider
    {
        private IClientService _clientService;

        public PersistendRefreshTokenAuthorizationServerProvider(IClientService clientService)
        {
            _clientService = clientService;
        }

        public override Task   ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;

            //省略了return之前context.SetError的代码
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret)) { return null; }

            var client =  _clientService.Get(clientId);
            if (client == null) { return null; }
            if (client.Secret != clientSecret) { return null; }

            context.OwinContext.Set<string>("as:client_id", clientId);
            context.OwinContext.Set<string>("as:clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());

            context.Validated(clientId);

            return base.ValidateClientAuthentication(context);
        }

        public override Task  GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);

            context.Validated(oAuthIdentity);

            return base.GrantClientCredentials(context);
        }

        public override  Task GrantResourceOwnerCredentials(
            OAuthGrantResourceOwnerCredentialsContext context)
        {
            //验证context.UserName与context.Password 
            var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            context.Validated(oAuthIdentity);

            return base.GrantResourceOwnerCredentials(context);
        }

        public override  Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var newId = new ClaimsIdentity(context.Ticket.Identity);
            newId.AddClaim(new Claim("newClaim", "refreshToken"));
            var newTicket = new AuthenticationTicket(newId, context.Ticket.Properties);
            context.Validated(newTicket);

            return base.GrantRefreshToken(context);
        }
    }
}