using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace Rico.S03.OwinOauthWeb.Sericies
{
    public class ClientRepository : IClientRepository
    {
        private static readonly Client[] _clients;

        static ClientRepository()
        {
            var json = File.ReadAllText(HostingEnvironment.MapPath("~/S05-PersintendRefreshToken/json/clients.json"));
            _clients = JsonConvert.DeserializeObject<Client[]>(json);
        }

        //public async Task<Client> FindById(Guid id)
        //{
        //    return _clients.Where(x => x.Id == id).FirstOrDefaultAsync();
        //}

        public Client FindById(string id)
        {
            return _clients.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}