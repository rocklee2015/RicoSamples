using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rico.S03.OwinOauthWeb.Sericies
{
    public class Client
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int RefreshTokenLifeTime { get; set; }
        public DateTime DateAdded { get; set; }
    }
}