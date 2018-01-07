using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Rico.S03.OwinOauthClientTest
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class S03_ResouceOwnerlApiTest
    {
        private HttpClient _httpClient;

        public S03_ResouceOwnerlApiTest()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:9000");
        }
        [TestMethod]
        public async Task GetAccesssToken_By_ResourceOwner_PasswordCredentialsGrant()
        {
            var accessToken = await GetAccessToken();

            Console.WriteLine(accessToken);
            Assert.IsNotNull(accessToken);
        }

        [TestMethod]
        public async Task Call_WebAPI_By_Resource_Owner_Password_Credentials_Grant()
        {
            var token = await GetAccessToken();
            Console.WriteLine(token);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var resp = await _httpClient.GetAsync("/api/user/GetCurrent");
            var body =await resp.Content.ReadAsStringAsync();

            Console.WriteLine(body);
            Assert.AreEqual("ricolee", body);
           
        }
        private async Task<string> GetAccessToken()
        {
            var clientId = "1234";
            var clientSecret = "5678";

            var parameters = new Dictionary<string, string>();
            parameters.Add("grant_type", "password");
            parameters.Add("username", "rico");
            parameters.Add("password", "asdf");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret))
                );

            var response = await _httpClient.PostAsync("/token-basic", new FormUrlEncodedContent(parameters));
            var responseValue = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JObject.Parse(responseValue)["access_token"].Value<string>();
            }
            else
            {
                Console.WriteLine(responseValue);
                return string.Empty;
            }
        }
    }
}
