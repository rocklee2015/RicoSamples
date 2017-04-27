using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Rico.OwinWebApi.Controller
{
    public class LoginController:ApiController
    {
        [HttpGet]
        public Task<string> Login()
        {
            return Task.FromResult("Login Test");

        }

    }
}
