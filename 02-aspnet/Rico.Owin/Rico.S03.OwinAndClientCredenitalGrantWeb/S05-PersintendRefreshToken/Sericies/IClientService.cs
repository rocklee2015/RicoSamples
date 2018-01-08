using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Rico.S03.OwinOauthWeb.Sericies
{
    public interface IClientService
    {
       Client Get(string clientId);
    }
}