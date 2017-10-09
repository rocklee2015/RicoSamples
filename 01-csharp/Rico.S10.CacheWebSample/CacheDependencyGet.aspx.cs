using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rico.S10.CacheWebSample
{
    public partial class CacheDependencyGet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //直接打开本页面，输出缓存依赖项测试
            //当更改D:\123.txt之后，在刷新，输出空，表明该Cache是依赖于D:\123.txt的
            Response.Write(HttpContext.Current.Cache["cache-dependency"]);

        }
    }
}