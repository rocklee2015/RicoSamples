using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Rico.CsharpGrammarNet461.S14.Net
{
    /// <summary>
    /// http://www.cnblogs.com/kissdodog/archive/2013/02/19/2917004.html
    /// </summary>

    [TestClass]
    public class P01_WebClient : BaseTest
    {
        [TestMethod]
        public void WebClient_SimpleRequest()
        {
            WebClient wc = new WebClient();
            wc.BaseAddress = "http://www.baidu.com/";   //设置根目录
            wc.Encoding = Encoding.UTF8;                    //设置按照何种编码访问，如果不加此行，获取到的字符串中文将是乱码
            wc.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
            string str = wc.DownloadString("/");
           // Console.WriteLine(str);
            Console.WriteLine("--------header-------------");
            WebHeaderCollection headers = wc.ResponseHeaders;   //获取响应头信息
            foreach (string headName in headers)
            {
                Console.WriteLine(headName + ":" + headers.Get(headName));
            }
            Console.WriteLine("--------query string-------------");
            Console.WriteLine(wc.QueryString.Count);    //输出0

        }

        [TestMethod]
        public void WebClient_OpenRead_ByStream()
        {
            WebClient wc = new WebClient();
            wc.BaseAddress = "http://www.baidu.com/";
            wc.Encoding = Encoding.UTF8;
            //----------------------以下为OpenRead()以流的方式读取----------------------
            wc.Headers.Add("Accept", "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*");
            wc.Headers.Add("Accept-Language", "zh-cn");
            wc.Headers.Add("UA-CPU", "x86");
            //wc.Headers.Add("Accept-Encoding","gzip, deflate");    //因为我们的程序无法进行gzip解码所以如果这样请求获得的资源可能无法解码。当然我们可以给程序加入gzip处理的模块 那是题外话了。
            wc.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
            //Headers   用于添加添加请求的头信息
            System.IO.Stream objStream = wc.OpenRead("search/error.html");      //获取访问流
            System.IO.StreamReader _read = new System.IO.StreamReader(objStream, System.Text.Encoding.UTF8);    //新建一个读取流，用指定的编码读取，此处是utf-8
            Console.Write(_read.ReadToEnd());   //输出读取到的字符串
        }

        [TestMethod]
        public void WebClient_DownloadFile()
        {
            WebClient wc = new WebClient();
            var imageName = $"{BaseDirectory}\\baidu.gif";
            wc.DownloadFile("http://www.baidu.com/img/shouye_b5486898c692066bd2cbaeda86d74448.gif", imageName);     //将远程文件保存到本地

            Assert.IsTrue(File.Exists(imageName));

            File.Delete(imageName);
        }
        [TestMethod]
        public void WebClient_DownloadFileAsBytes()
        {
            WebClient wc = new WebClient();
            var imageName = $"{BaseDirectory}\\baidu.gif";
            byte[] bytes = wc.DownloadData("http://www.baidu.com/img/shouye_b5486898c692066bd2cbaeda86d74448.gif");
            using (FileStream fs = new FileStream(imageName, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
         
            Assert.IsTrue(File.Exists(imageName));

            File.Delete(imageName);
        }
    }
}
