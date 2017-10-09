using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rico.S10.CacheWebSample
{
    public partial class CacheTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Person p = new Person();
            p.Id = 1;
            p.Name = "诸葛亮";

            Cache cache = HttpRuntime.Cache;
            cache.Insert("AA", p);
            cache.Insert("BB", "字符串");

            Response.Write("BB".PadRight(20,'-') + "<br/>");
            Response.Write(cache.Get("BB").ToString() + "<br/>");     //输出 字符串

            Person p2 = cache["AA"] as Person;
            Response.Write("AA".PadRight(20, '-') + "<br/>");
            Response.Write(p2.Id + " : " + p2.Name + "<br/>");        //输出 1 : 诸葛亮

            Response.Write("缓存可用字节".PadRight(20, '-') + "<br/>");
            Response.Write(cache.EffectivePrivateBytesLimit + "<br/>");   //-1 这是一个只读属性，那就没什么好说了，只能输出来看看了，但是-1是什么意思呢？无限吗

            Response.Write("开始移除项之前可以使用到".PadRight(20, '-') + "<br/>");
            Response.Write(cache.EffectivePercentagePhysicalMemoryLimit + "<br/>");   //98    开始移除项之前可以使用到98%

            Response.Write("缓存个数".PadRight(20, '-') + "<br/>");
            Response.Write(cache.Count + "<br/>");        //输出 3

            Response.Write("输出 BB ,再删除 BB".PadRight(20, '-') + "<br/>");
            Response.Write(cache["BB"] + "<br/>");        //输出 字符串 支持索引器式的读取

            cache.Remove("BB");        //从cache中移除一项
            Response.Write("~~~" + cache["BB"] + "~~~" + "<br/>");    //移除了输出 null，但程序不报错

            Response.Write("遍历缓存".PadRight(20, '-') + "<br/>");
            foreach (var obj in cache)
            {
                Response.Write(obj.GetType() + "<br/>");    //输出不知道什么鸟东西
            }
        }

     
    }
    public class Person
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

}