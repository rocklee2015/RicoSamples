using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sodao.Spider.Tmall
{
    public class TmallSpider : SpiderBase
    {
        public override string Start()
        {
            throw new NotImplementedException();
        }
        public override string GetContentByUrl(string url, string encode = "utf-8")
        {
            string strResult = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//HttpWebRequest 类对 WebRequest 中定义的属性和方法提供支持，也对使用户能够直接与使用 									                  HTTP 的服务器交互的附加属性和方法提供支持,声明一个HttpWebRequest请求
                request.KeepAlive = true;
                request.Timeout = 30000;//设置连接超时时间    
                request.ContentType = "text/html";
                //request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
                request.UserAgent = "Mozilla/5.0 (compatible;Windows NT 6.1; WOW64;Trident/6.0;MSIE 9.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.27 Safari/537.36";
                //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.65 Safari/537.36";
                request.Accept = "*/*";
                request.KeepAlive = true;
                request.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
                request.AutomaticDecompression = DecompressionMethods.GZip;
                request.CookieContainer = new CookieContainer();
                //request.AllowAutoRedirect = false;
                //request.CacheControl = "no-cache";
                //request.AddHeader("Pragma", "No-Cache");
                //request.Method = "get";
                //request.UserAgent = "Mozilla/5.0 (compatible;Windows NT 6.1; WOW64;Trident/6.0;MSIE 9.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.27 Safari/537.36";
                request.Headers.Set("Cache-Control", "no-cache");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.GetEncoding(encode);//utf-8
                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                strResult = streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return strResult;
        }
    }
}
