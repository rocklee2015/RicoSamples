using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Rico.S03.OwinOauthClientTest
{
    [TestClass]
    public class ApiTest
    {
        private HttpClient _httpClient;

        public ApiTest()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:9000");
        }
        [TestMethod]
        public async Task Access_API()
        {
            var token = await GetAccessToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var apiResult = await _httpClient.GetAsync("/api/values/get");

            var apiBody =await apiResult.Content.ReadAsStringAsync();

            Console.WriteLine(apiBody);

            //var result = JObject.Parse(apiBody);
           
            //Assert.AreEqual(2, result.Count);
            

        }
        private async Task<string> GetAccessToken()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("client_id", "1234");
            parameters.Add("client_secret", "5678");
            parameters.Add("grant_type", "client_credentials");

            var response = await _httpClient.PostAsync("/token-form", new FormUrlEncodedContent(parameters));
            var responseValue = await response.Content.ReadAsStringAsync();

            return JObject.Parse(responseValue)["access_token"].Value<string>();
        }
    }
}
