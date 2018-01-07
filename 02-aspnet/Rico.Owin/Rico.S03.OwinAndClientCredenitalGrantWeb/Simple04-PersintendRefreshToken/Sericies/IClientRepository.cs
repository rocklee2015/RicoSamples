using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S03.OwinOauthWeb.Sericies
{
    public interface IClientRepository
    {
        Client FindById(string id);
    }
}
