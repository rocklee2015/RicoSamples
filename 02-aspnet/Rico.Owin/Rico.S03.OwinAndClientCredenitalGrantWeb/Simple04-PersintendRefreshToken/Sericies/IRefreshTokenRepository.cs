using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S03.OwinOauthWeb.Sericies
{
    public interface IRefreshTokenRepository
    {
        RefreshToken FindById(string Id);

        Task<bool> Insert(RefreshToken refreshToken);

        Task<bool> Delete(string Id);
    }
}
