using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rico.S03.OwinOauthWeb.Controller
{
    public class UserController : ApiController
    {
        [Authorize]
        public string GetCurrent()
        {
            return User.Identity.Name;
            //这里可以调用后台用户服务，获取用户相关数所，或者验证用户权限进行相应的操作
        }
    }
}
