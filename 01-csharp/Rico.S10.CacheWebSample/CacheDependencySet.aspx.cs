using System;
using System.IO;
using System.Web;
using System.Web.Caching;

namespace Rico.S10.CacheWebSample
{
    public partial class CacheDependencySet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cache cache = HttpContext.Current.Cache;
            //var path = new DirectoryInfo("../../").FullName;  在控制台可以获取，在asp.net 不可用
            var path = Server.MapPath("~");
            path += "readme.txt";
            //文件缓存依赖
            cache.Insert("cache-dependency", "依赖项测试，依赖文件：" + path, new CacheDependency(path));
            //这时候在about.aspx页面添加一行代码，当更改一下D:123.txt时，cache["cc"]会立即被清空
            Response.Write($"设置成功：{DateTime.Now} 依赖文件：{path}");
        }
    }
}