## Owin + Oauth

# 引用nuget
1. 第一步：安装 Microsoft.Owin
2. 第二步：安装 Microsoft.Owin.Security.OAuth 构造MyAuthorizationServerProvider
3. 第三步：安装 Microsoft.AspNet.Identity.Owin 才能使用UseOAuthBearerTokens 扩展方法
4. 第四步：安装 Microsoft.Owin.Hosting 和 Microsoft.Owin.Host.HttpListener 才能将服务运行起来（如果是网站项目则不需要）

## 测试
注意：使用Postman 测试时要填写一下信息
body(x-www-form-urlencoded) 三个都要填写哦
client_id:1234
client_secret:5678
grant_type:client_credentials
