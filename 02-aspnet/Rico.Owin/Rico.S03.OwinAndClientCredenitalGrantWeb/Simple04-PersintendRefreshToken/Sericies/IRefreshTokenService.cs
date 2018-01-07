using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S03.OwinOauthWeb.Sericies
{
    public interface IRefreshTokenService
    {
        RefreshToken Get(string Id);
        Task<bool> Save(RefreshToken refreshToken);
        Task<bool> Remove(string Id);
    }
}
