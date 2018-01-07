using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Rico.S03.OwinOauthWeb.Sericies
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private IRefreshTokenRepository _refreshTokenRepository;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public RefreshToken Get(string Id)
        {
            return _refreshTokenRepository.FindById(Id);
        }

        public async Task<bool> Save(RefreshToken refreshToken)
        {
            return await _refreshTokenRepository.Insert(refreshToken);
        }

        public async Task<bool> Remove(string Id)
        {
            return await _refreshTokenRepository.Delete(Id);
        }
    }
}