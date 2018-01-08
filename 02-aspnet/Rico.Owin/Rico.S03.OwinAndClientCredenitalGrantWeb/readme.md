## Owin + Oauth

# 引用nuget
1. 第一步：安装 Microsoft.Owin
2. 第二步：安装 Microsoft.Owin.Security.OAuth 构造MyAuthorizationServerProvider
3. 第三步：安装 Microsoft.AspNet.Identity.Owin 才能使用UseOAuthBearerTokens 扩展方法
4. 第四步：安装 Microsoft.Owin.Host.SystemWeb（安装这个web 才能跑起来）

## Client Credentials Grant的授权方式就是只验证客户端（Client），不验证用户（Resource Owner）只要客户端通过验证就发access token