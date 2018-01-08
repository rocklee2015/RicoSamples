using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Rico.S03.ConfigConst;

namespace Rico.S03.OwinOauthClientTest
{
    [TestClass]
    public class S02_ClientIdAccessApiTest
    {
        private HttpClient _httpClient;

        public S02_ClientIdAccessApiTest()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:9000");
        }
        [TestMethod]
        public async Task ClientIdAccessApi()
        {
            var token = await GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var apiResult = await _httpClient.GetAsync("/api/values/get");

            var apiBody =await apiResult.Content.ReadAsStringAsync();

            Console.WriteLine(apiBody);
            Assert.IsTrue(apiBody.Contains("value1"));

        }

        private async Task<string> GetAccessToken()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("client_id", RicoOauth.clientId);
            parameters.Add("client_secret", RicoOauth.clientSecret);
            parameters.Add("grant_type", "client_credentials");

            var response = await _httpClient.PostAsync("/token-s01", new FormUrlEncodedContent(parameters));
            var responseValue = await response.Content.ReadAsStringAsync();

            return JObject.Parse(responseValue)["access_token"].Value<string>();
        }
    }
}
