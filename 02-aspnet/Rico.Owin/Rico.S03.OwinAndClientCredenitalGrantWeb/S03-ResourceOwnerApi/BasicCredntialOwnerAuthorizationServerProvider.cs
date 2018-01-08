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
    public class BasicCredntialOwnerAuthorizationServerProvider : OAuthAuthorizationServerProvider
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
            //从头部获取
            context.TryGetBasicCredentials(out clientId, out clientSecret);

            if (clientId == RicoOauth.clientId && clientSecret == RicoOauth.clientSecret)
            {
                context.Validated(clientId);
            }

            return base.ValidateClientAuthentication(context);
        }

        /// <summary>
        /// 授权客户端凭证(在这里这个可以不用)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        //public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        //{
        //    var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
        //    oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, "iOS App"));
        //    var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
        //    context.Validated(ticket);

        //    return base.GrantClientCredentials(context);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //调用后台的登录服务验证用户名与密码
            if (context.UserName == RicoOauth.username && context.Password == RicoOauth.password)
            {
                var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
                context.Validated(ticket);
               
            }
            else
            {
                context.SetError("密码错误！");
                context.Rejected();
            }
         
           
            await base.GrantResourceOwnerCredentials(context);
        }

       
    }
}
