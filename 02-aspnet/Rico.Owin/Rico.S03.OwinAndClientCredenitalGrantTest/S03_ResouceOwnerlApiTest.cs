using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Rico.S03.ConfigConst;

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
            Assert.AreEqual($"\"{RicoOauth.username}\"", body);
           
        }
        private async Task<string> GetAccessToken()
        {
            var clientId = RicoOauth.clientId;
            var clientSecret = RicoOauth.clientSecret;

            var parameters = new Dictionary<string, string>();
            parameters.Add("grant_type", "password");
            parameters.Add("username", RicoOauth.username);
            parameters.Add("password", RicoOauth.password);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret))
                );

            var response = await _httpClient.PostAsync("/token-s03", new FormUrlEncodedContent(parameters));
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
