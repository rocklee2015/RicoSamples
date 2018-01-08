using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Rico.S03.OwinOauthWeb.Sericies
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public Client Get(string clientId)
        {
            return _clientRepository.FindById(clientId);
        }
    }
}