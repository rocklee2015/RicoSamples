using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sodao.Spider.Tmall
{
    public abstract class SpiderBase
    {
        public virtual string GetContentByUrl(string url, string encode = "utf-8")
        {
            string strResult = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//HttpWebRequest 类对 WebRequest 中定义的属性和方法提供支持，也对使用户能够直接与使用 									                  HTTP 的服务器交互的附加属性和方法提供支持,声明一个HttpWebRequest请求
                request.Timeout = 30000;//设置连接超时时间    

                request.Headers.Add("Pragma", "No-Cache");

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
        public abstract string Start();
    }
}
