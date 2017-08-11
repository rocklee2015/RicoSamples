using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.S01.OwinWebApiOauthTest
{
    [TestClass]
    public class OAuthClientTest
    {
        private readonly HttpClient _httpClient;

        public OAuthClientTest()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:9000") };
        }

        [TestMethod]
        public void Get_Accesss_Token_By_Client_Credentials_Grant()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("client_id", "1231");
            parameters.Add("client_secret", "5678");
            parameters.Add("grant_type", "client_credentials");

            Console.WriteLine(_httpClient.PostAsync("/token", new FormUrlEncodedContent(parameters))
                .Result.Content.ReadAsStringAsync().Result);
            Console.WriteLine("Result");
        }
        [TestMethod]
        public void Get_Accesss_Token_By_Client_Credentials_GrantByBase()
        {
            var clientId = "1234";
            var clientSecret = "5678";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret)));

            var parameters = new Dictionary<string, string>();
            parameters.Add("grant_type", "client_credentials");

            Console.WriteLine(_httpClient.PostAsync("/token", new FormUrlEncodedContent(parameters))
                .Result.Content.ReadAsStringAsync().Result);
        }


    }
}
