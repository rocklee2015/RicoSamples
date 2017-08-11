
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Rico.S01.OwinWebApi.Controller
{
    public class TestController:ApiController
    {
        [HttpGet]
        public Task<string> Print()
        {
            Task.Delay(10000);
            return Task.FromResult("Owin Web api Print Method");
        }

        public Task<string> ParamTest([FromBody] Person input)
        {
            //HttpRequestMessage staticContext = HttpContent..Request;
            //string staticUrl = staticContext.Url.ToString();

            ////var request = Request;
            //var httpContent = ControllerContext.Request.Content;
            //var asyncContent = httpContent.ReadAsStringAsync().Result;

            return Task.FromResult("");
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
