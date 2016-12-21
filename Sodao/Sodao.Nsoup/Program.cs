using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sodao.Spider

{
    public class Spider
    {
        private CookieContainer CC = new CookieContainer();
        public void Excute()
        {
            var url = "https://list.tmall.com/search_product.htm?q=%E7%BE%8E%E5%A6%86&sort=d&s=0&style=w&from=.list.pc_1_searchbutton";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//HttpWebRequest 类对 WebRequest 中定义的属性和方法提供支持，也对使用户能够直接与使用 									                  HTTP 的服务器交互的附加属性和方法提供支持,声明一个HttpWebRequest请求
            #region
            request.KeepAlive = true;
            request.Timeout = 50000;//设置连接超时时间    
            request.ContentType = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            //request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
            //request.UserAgent = "Mozilla/5.0 (compatible;Windows NT 6.1; WOW64;Trident/6.0;MSIE 9.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.27 Safari/537.36";
            //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.65 Safari/537.36";
            request.UserAgent = " Mozilla / 5.0(Windows NT 6.1; WOW64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 43.0.2357.65 Safari / 537.36";
            request.Accept = "*/*";
            request.KeepAlive = true;
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            request.Headers.Add("accept-encoding", "gzip, deflate, sdch");
            request.AutomaticDecompression = DecompressionMethods.GZip;
            BugFix_CookieDomain(CC);
            //request.CookieContainer = CC;
            //request.AllowAutoRedirect = false;
            //request.CacheControl = "no-cache";
            request.Headers.Add("Pragma", "No-Cache");
          //  request.Headers.Set("Cookie", "cna=OYnpDcsG4GkCATy6Fwf1Zkwo; x=__ll%3D-1%26_ato%3D0; otherx=e%3D1%26p%3D*%26s%3D0%26c%3D0%26f%3D0%26g%3D0%26t%3D0; _tb_token_=n9K1IHBwZMp; cookie2=1c889e270387ee477ee47b3cdb09e96b; t=b92353c060c9a0debd9ea59911c706aa; tracknick=xuquan0615; _med=dw:1920&dh:1080&pw:1920&ph:1080&ist:0; _m_h5_tk=602ce77f73b4d858de17620c48a23664_1472467220709; _m_h5_tk_enc=a9b162f96b1ba63b01594d56aa110dc6; tt=tmall-main; pnm_cku822=091UW5TcyMNYQwiAiwQRHhBfEF8QXtHcklnMWc%3D%7CUm5OcktxTnZIckZ4QnlAdCI%3D%7CU2xMHDJ7G2AHYg8hAS8WKAYmCFQ1Uz9YJlxyJHI%3D%7CVGhXd1llXGZZYV9lUW9VbldjVGlLdU10Sn9BeEN4THhNcU11SmQy%7CVWldfS0RMQU8CCgcPBJ4A2gSYUpqVHRaDFo%3D%7CVmhIGCUFOBgkEC0TMw8yCzUAIBwoFyoKNgs%2BAyMfKxQpCTUIMA1bDQ%3D%3D%7CV25Tbk5zU2xMcEl1VWtTaUlwJg%3D%3D; res=scroll%3A1903*10438-client%3A1903*964-offset%3A1903*10438-screen%3A1920*1080; cq=ccp%3D1; l=ApCQTOh-W83cUIOKp-/bnkvm4NDiWXSj; isg=AtPTBgWQgD80H0yrlGKc6fKaYlf_LWdKWoE2wIXwL_IpBPOmDVj3mjFWSMGQ");
            request.Referer = "https://list.tmall.com/search_product.htm?q=%C3%C0%D7%B1&type=p&spm=a220m.1000858.a2227oh.d100&xl=meizhuang_1&from=.list.pc_1_suggest";
            request.AllowAutoRedirect = false;
            //request.Method = "get";
            //request.UserAgent = "Mozilla/5.0 (compatible;Windows NT 6.1; WOW64;Trident/6.0;MSIE 9.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.27 Safari/537.36";

            #endregion
            //设置连接超时时间   
            NSoup.Nodes.Document doc = NSoup.NSoupClient.Parse(request.GetResponse().GetResponseStream(), "GB2312");
            var shopBoxs = doc.GetElementsByClass("shopBox");
            foreach (var shop in shopBoxs)
            {
                
                var shopName = shop.GetElementsByAttributeValue("class","sHi-title").Text;
                var shopUrlElement = shop.GetElementsByAttributeValue("class", "sHe-shop");
                var shopurl=shopUrlElement.Attr("href");
            }
            //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //{
            //    Stream streamReceive = response.GetResponseStream();
            //    Encoding encoding = Encoding.GetEncoding("GB2312");//utf-8
            //    StreamReader streamReader = new StreamReader(streamReceive, encoding);
            //    var strResult = streamReader.ReadToEnd();

              
            //}


        }
        private void BugFix_CookieDomain(CookieContainer cookieContainer)
        {
            System.Type _ContainerType = typeof(CookieContainer);
            Hashtable table = (Hashtable)_ContainerType.InvokeMember("m_domainTable",
                                       System.Reflection.BindingFlags.NonPublic |
                                       System.Reflection.BindingFlags.GetField |
                                       System.Reflection.BindingFlags.Instance,
                                       null,
                                       cookieContainer,
                                       new object[] { });
            ArrayList keys = new ArrayList(table.Keys);
            foreach (string keyObj in keys)
            {
                string key = (keyObj as string);
                if (key[0] == '.')
                {
                    string newKey = key.Remove(0, 1);
                    table[newKey] = table[keyObj];
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new Spider().Excute();
            //WebRequest webRequest = WebRequest.Create("https://list.tmall.com/search_product.htm?q=%E7%BE%8E%E5%A6%86&sort=d&s=0&style=w&from=.list.pc_1_searchbutton");

            //NSoup.Nodes.Document doc = NSoup.NSoupClient.Parse(webRequest.GetResponse().GetResponseStream(), "utf-8");
            //var div=doc.Select("div");
            //var first=div.Attr("id", "blog-sidecolumn");
        }
        private CookieContainer CC = new CookieContainer();


    }
}
