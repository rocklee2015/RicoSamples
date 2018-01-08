using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Rico.S03.OwinOauthWeb
{
    public class RefreshTokenAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            context.TryGetBasicCredentials(out clientId, out clientSecret);
             context.Validated(clientId);
            return base.ValidateClientAuthentication(context);
        }
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            //oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
            context.Validated(ticket);
            return base.GrantResourceOwnerCredentials(context);
        }

        /// <summary>
        /// 这个是不必要的
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        //public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        //{
        //    var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);

        //    var props = new AuthenticationProperties(new Dictionary<string, string>
        //        {
        //            { "as:client_id", context.ClientId }
        //        });
        //    var ticket = new AuthenticationTicket(oAuthIdentity, props);

        //    context.Validated(ticket);

        //    return base.GrantClientCredentials(context);
        //}

        //    public async override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        //    {
        //        var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
        //        var currentClient = context.ClientId;

        //        if (originalClient != currentClient)
        //        {
        //            context.Rejected();
        //            return;
        //        }

        //        var newId = new ClaimsIdentity(context.Ticket.Identity);
        //        newId.AddClaim(new Claim("newClaim", "refreshToken"));

        //        var newTicket = new AuthenticationTicket(newId, context.Ticket.Properties);
        //        context.Validated(newTicket);

        //        await base.GrantRefreshToken(context);
        //    }
    }
}