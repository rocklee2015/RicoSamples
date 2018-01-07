using Microsoft.Owin.Security.Infrastructure;
using Rico.S03.OwinOauthWeb.Sericies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;

namespace Rico.S03.OwinOauthWeb
{
    public class PersistendRefreshTokenProvider : AuthenticationTokenProvider
    {
        private IRefreshTokenService _refreshTokenService;

        public PersistendRefreshTokenProvider(IRefreshTokenService refreshTokenService)
        {
            _refreshTokenService = refreshTokenService;
        }

        public override async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var clietId = context.OwinContext.Get<string>("as:client_id");
            if (string.IsNullOrEmpty(clietId)) return;

            var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime");
            if (string.IsNullOrEmpty(refreshTokenLifeTime)) return;

            //generate access token
            RandomNumberGenerator cryptoRandomDataGenerator = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[50];
            cryptoRandomDataGenerator.GetBytes(buffer);
            var refreshTokenId = Convert.ToBase64String(buffer).TrimEnd('=').Replace('+', '-').Replace('/', '_');

            var refreshToken = new RefreshToken()
            {
                Id = refreshTokenId,
                ClientId = clietId,
                UserName = context.Ticket.Identity.Name,
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddSeconds(Convert.ToDouble(refreshTokenLifeTime)),
                ProtectedTicket = context.SerializeTicket()
            };

            context.Ticket.Properties.IssuedUtc = refreshToken.IssuedUtc;
            context.Ticket.Properties.ExpiresUtc = refreshToken.ExpiresUtc;

            if (await _refreshTokenService.Save(refreshToken))
            {
                context.SetToken(refreshTokenId);
            }
        }

        public override async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            var refreshToken = _refreshTokenService.Get(context.Token);

            if (refreshToken != null)
            {
                context.DeserializeTicket(refreshToken.ProtectedTicket);
                var result = await _refreshTokenService.Remove(context.Token);
            }
        }
    }

}