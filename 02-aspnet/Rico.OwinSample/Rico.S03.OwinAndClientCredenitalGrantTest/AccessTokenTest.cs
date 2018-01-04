using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rico.S03.OwinOauthClientTest
{
    /// <summary>
    /// url:http://www.cnblogs.com/dudu/p/4569857.html
    /// </summary>
    [TestClass]
    public class AccessTokenTest
    {
        private readonly HttpClient _httpClient;

        public AccessTokenTest()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:9000") };
        }

        [TestMethod]
        public async Task GetToken_ByClientCredentialsGrantForm_Return_OK()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("client_id", "1234");
            parameters.Add("client_secret", "5678");
            parameters.Add("grant_type", "client_credentials");

            var result = await _httpClient.PostAsync("/token-form", new FormUrlEncodedContent(parameters));
            Console.WriteLine(result);

            var respBody = await result.Content.ReadAsStringAsync();
            Console.WriteLine(respBody);

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(respBody.Contains("access_token"));
            
        }

        [TestMethod]
        public async Task GetToken_ByClientCredentialsGrantForm_Return_BadRequest()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("client_id", "123"); //密码错了
            parameters.Add("client_secret", "5678");
            parameters.Add("grant_type", "client_credentials");

            var result = await _httpClient.PostAsync("/token-form", new FormUrlEncodedContent(parameters));
            Console.WriteLine(result);

            var respBody = await result.Content.ReadAsStringAsync();
            Console.WriteLine(respBody);

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.IsTrue(respBody.Contains("error"));
        }
        [TestMethod]
        public async Task GetToken_ByClientCredentialsGrantBasic_Return_BadRequest()
        {
            var clientId = "1234";
            var clientSecret = "5678";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret)));

            var parameters = new Dictionary<string, string>();
            parameters.Add("grant_type", "client_credentials");

            var result = await _httpClient.PostAsync("/token-basic", new FormUrlEncodedContent(parameters));
            Console.WriteLine(result);

            var respBody = await result.Content.ReadAsStringAsync();
            Console.WriteLine(respBody);

            Assert.IsTrue(respBody.Contains("access_token"));
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
