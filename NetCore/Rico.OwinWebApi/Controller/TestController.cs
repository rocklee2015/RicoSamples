using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Rico.OwinWebApi.Controller
{
    public class TestController:ApiController
    {
        [HttpGet]
        public Task<string> Print()
        {
            return Task.FromResult("Owin Web api Print Method");
        }
    }
}
