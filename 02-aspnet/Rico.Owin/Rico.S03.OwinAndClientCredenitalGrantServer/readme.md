## Owin + Oauth

# ����nuget
1. ��һ������װ Microsoft.Owin
2. �ڶ�������װ Microsoft.Owin.Security.OAuth ����MyAuthorizationServerProvider
3. ����������װ Microsoft.AspNet.Identity.Owin ����ʹ��UseOAuthBearerTokens ��չ����
4. ���Ĳ�����װ Microsoft.Owin.Hosting �� Microsoft.Owin.Host.HttpListener ���ܽ����������������������վ��Ŀ����Ҫ��

## ����
ע�⣺ʹ��Postman ����ʱҪ��дһ����Ϣ
body(x-www-form-urlencoded) ������Ҫ��дŶ
client_id:1234
client_secret:5678
grant_type:client_credentials
