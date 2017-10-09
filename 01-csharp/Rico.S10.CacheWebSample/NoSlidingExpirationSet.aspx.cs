using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rico.S10.CacheWebSample
{
    public partial class CacheExpiration_Set : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cache cache = HttpContext.Current.Cache;
            //5秒后就到期
            //cache.Insert("DD", "绝对过期测试", null, DateTime.Now.AddSeconds(5), System.Web.Caching.Cache.NoSlidingExpiration);
            var noSlidingExpiration = "noSlidingExpiration";
            var expiredTime = 5;
            cache.Insert(nameof(noSlidingExpiration), "绝对过期", null, DateTime.UtcNow.AddSeconds(expiredTime), System.Web.Caching.Cache.NoSlidingExpiration);

            Response.Write($"Key={nameof(noSlidingExpiration)},Value=绝对过期,过期时间{expiredTime}秒");
        }
    }
}