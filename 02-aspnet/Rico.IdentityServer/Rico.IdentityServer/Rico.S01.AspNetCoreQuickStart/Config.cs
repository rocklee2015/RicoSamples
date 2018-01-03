using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace Rico.S01.AspNetCoreQuickStart
{
    public class Config
    {
        public static IEnumerable<Scope> GetScopes()
        {
            return new List<Scope>
            {
                new Scope
                {
                    Name = "zeroapi",
                    Description = "LineZero ASP.NET Core Web API"
                }
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "linezeroclient",

                    //使用clientid / secret进行身份验证
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // 加密验证
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    // client可以访问的范围，在上面定义的。
                    AllowedScopes = new List<string>
                    {
                        "zeroapi"
                    }
                }
            };
        }
    }
}
