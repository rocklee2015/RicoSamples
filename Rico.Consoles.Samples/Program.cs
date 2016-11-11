using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rico.Consoles.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            string d = "<div class=\"shopbox\"><div>aa</div><span></span></div>";
            Regex reg = new Regex(@"(?<=<div[^>]*?class=""(\s*\w*)(shopbox)(\s*\w*)""[^>]*?>).*?(?=</div>)");
            MatchCollection mc = reg.Matches(d);
            foreach (Match m in mc)
            {
                Console.WriteLine(m.Groups[0].Value);
                //richTextBox2.Text += regTag.Replace(m.Groups[1].Value, "") + "\n";
            }
            Console.ReadKey();

            //string source = " shopbox asdf";
            //Regex reg2 = new Regex("^((?!shopbox).)*$");
            //if (reg2.IsMatch(source))
            //{
            //    Console.Write(reg2.Match(source));
            //}
            //Console.ReadKey();
            //if (reg.IsMatch(d))
            //{
            //    Console.Write(reg.Match(d));
            //}
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://list.tmall.com/search_product.htm?spm=a220m.1000858.1000724.7.SDIn7Z&cat=50031545&sort=s&style=w&active=1&industryCatId=50031545#J_Filter");    //创建一个请求示例
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();  //获取响应，即发送请求
            //Stream responseStream = response.GetResponseStream();
            //StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
            //string html = streamReader.ReadToEnd();
            //Console.WriteLine(html);
            //try
            //{
            //    var url = @"https://list.tmall.com/search_product.htm?q=%E7%BE%8E%E5%A6%86&sort=d&s=0&style=w&from=.list.pc_1_searchbutton";
            //    if (url.IndexOf("https:") == -1)
            //    {
            //        url = "https:" + url;
            //    }
            //    Uri uri = new Uri(url);
            //    HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(uri);
            //    myReq.UserAgent = "User-Agent:Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705";
            //    myReq.Accept = "*/*";
            //    myReq.KeepAlive = true;
            //    myReq.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
            //    HttpWebResponse result = (HttpWebResponse)myReq.GetResponse();
            //    Stream receviceStream = result.GetResponseStream();
            //    StreamReader readerOfStream = new StreamReader(receviceStream, System.Text.Encoding.GetEncoding("gbk"));
            //    string strHTML = readerOfStream.ReadToEnd();
            //    readerOfStream.Close();
            //    receviceStream.Close();
            //    result.Close();
            //}
            //catch (Exception es)
            //{
            //}


        }
    }
   
}
