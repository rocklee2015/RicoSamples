using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S03.OwinOauthClientTest
{
    /*
     * http://www.cnblogs.com/dudu/p/oauth-refresh-token.html
     * refresh token 是专用于刷新 access token 的 token。
     * 为什么要刷新 access token 呢？
     * 一是因为 access token 是有过期时间的，到了过期时间这个 access token 就失效，需要刷新；
     * 二是因为一个 access token 会关联一定的用户权限，如果用户授权更改了，这个 access token 需要被刷新以关联新的权限。
     * 为什么要专门用一个 token 去更新 access token 呢？
     * 如果没有 refresh token，也可以刷新 access token，但每次刷新都要用户输入登录用户名与密码，多麻烦。
     * 有了 refresh token，可以减少这个麻烦，客户端直接用 refresh token 去更新 access token，无需用户进行额外的操作。
     */


    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class S04_RefreshToken
    {
        private HttpClient _httpClient;

        public S04_RefreshToken()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:9000");
        }
    
        [TestMethod]
        public async Task GetAccessTokenTest()
        {
            var result = await GetAccessToken();

            var access_token= JObject.Parse(result)["access_token"].Value<string>();
            var refresh_token = JObject.Parse(result)["refresh_token"].Value<string>();
            Console.WriteLine(access_token);
            Console.WriteLine(refresh_token);
            Assert.IsNotNull(access_token);
            Assert.IsNotNull(refresh_token);
        }

        private async Task<string> GetAccessToken()
        {
            //var clientId = "1234";
            //var clientSecret = "5678";
            var clientId = "[clientId]";
            var clientSecret = "[clientSecret]";

            var parameters = new Dictionary<string, string>();
            parameters.Add("grant_type", "password");
            parameters.Add("username", "[username]");
            parameters.Add("password", "[password]");
            //parameters.Add("username", "rico");
            //parameters.Add("password", "asdf");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret))
                );

            var response = await _httpClient.PostAsync("/token-refresh", new FormUrlEncodedContent(parameters));
            var responseValue = await response.Content.ReadAsStringAsync();

            return responseValue;
        }
        [TestMethod]
        public async Task GetAccessTokenByRefreshTokenTest()
        {
            //var clientId = "1234";
            //var clientSecret = "5678";

            var clientId = "[clientId]";
            var clientSecret = "[clientSecret]";

            var result = await GetAccessToken();

            var refresh_token = JObject.Parse(result)["refresh_token"].Value<string>();

            //不需要用户名与密码就可以刷新 access token
            var parameters = new Dictionary<string, string>();
            parameters.Add("grant_type", "refresh_token");
            parameters.Add("refresh_token", refresh_token);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret)));

            var response = await _httpClient.PostAsync("/token-refresh", new FormUrlEncodedContent(parameters));
            var responseValue = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseValue);
        }
    }
}
