using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rico.S10.CacheWebSample
{
    public partial class CacheExpiration_Get : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //先打开index.aspx添加到缓存 然后立即打开本页面，输出 绝对过期测试
            //持续刷新5秒后，不会再输出　　绝对过期测试
            Response.Write(HttpContext.Current.Cache["DD"]);

        }
    }
}