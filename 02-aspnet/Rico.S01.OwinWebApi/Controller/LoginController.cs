using System.Threading.Tasks;
using System.Web.Http;

namespace Rico.S01.OwinWebApi.Controller
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
