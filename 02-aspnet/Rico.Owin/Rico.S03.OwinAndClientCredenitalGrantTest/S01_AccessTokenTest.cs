using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rico.S03.ConfigConst;

namespace Rico.S03.OwinOauthClientTest
{
    /// <summary>
    /// Form 和 Basic 获取 AccessToken
    /// url:http://www.cnblogs.com/dudu/p/4569857.html
    /// </summary>
    [TestClass]
    public class S01_AccessTokenTest
    {
        private readonly HttpClient _httpClient;

        public S01_AccessTokenTest()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:9000") };
        }

        [TestMethod]
        public async Task GetToken_ByClientCredentialsGrantForm_Return_OK()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("client_id", RicoOauth.clientId);
            parameters.Add("client_secret", RicoOauth.clientSecret);
            parameters.Add("grant_type", "client_credentials");

            var result = await _httpClient.PostAsync("/token-s01", new FormUrlEncodedContent(parameters));
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
            parameters.Add("client_id", RicoOauth.clientId);
            parameters.Add("client_secret", "test");
            parameters.Add("grant_type", "client_credentials");

            var result = await _httpClient.PostAsync("/token-s01", new FormUrlEncodedContent(parameters));
            Console.WriteLine(result);

            var respBody = await result.Content.ReadAsStringAsync();
            Console.WriteLine(respBody);

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.IsTrue(respBody.Contains("error"));
        }
        [TestMethod]
        public async Task GetToken_ByClientCredentialsGrantBasic_Return_BadRequest()
        {
            var clientId = RicoOauth.clientId;
            var clientSecret = RicoOauth.clientSecret;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret)));

            var parameters = new Dictionary<string, string>();
            parameters.Add("grant_type", "client_credentials");

            var result = await _httpClient.PostAsync("/token-s02", new FormUrlEncodedContent(parameters));
            Console.WriteLine(result);

            var respBody = await result.Content.ReadAsStringAsync();
            Console.WriteLine(respBody);

            Assert.IsTrue(respBody.Contains("access_token"));
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
