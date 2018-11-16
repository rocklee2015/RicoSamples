using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Ric.S01.MvcDemo.Controllers
{
    public class S01ClientBrowserController : Controller
    {
        // GET: ClientBrowser
        public ActionResult Index()
        {
            string userAgent = Request.UserAgent == null ? "无" : Request.UserAgent;
            List<string> clientInfos = new List<string>();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("您的系统信息为：");
            clientInfos.Add("客户端IP[Page.Request.UserHostAddress]：" + Request.UserHostAddress);
            clientInfos.Add("浏览器类型[Request.Browser.Browser]：" + Request.Browser.Browser);
            clientInfos.Add("浏览器标识[Request.Browser.Id]：" + Request.Browser.Id);
            clientInfos.Add("浏览器版本号[Request.Browser.Version]：" + Request.Browser.Version);
            clientInfos.Add("浏览器是不是测试版本[Request.Browser.Beta]：" + Request.Browser.Beta);
            clientInfos.Add("浏览器类型[Request.Browser.Type]：" + Request.Browser.Type);
            clientInfos.Add("是否支持框架网页[Request.Browser.Frames]：" + Request.Browser.Frames);
            clientInfos.Add("是否支持Cookie[Request.Browser.Cookies]：" + Request.Browser.Cookies);
            clientInfos.Add("浏览器JScript版本[Request.Browser.JScriptVersion]：" + Request.Browser.JScriptVersion);

            clientInfos.Add("浏览器类型[Request.Browser.Type]：" + Request.Browser.Type);
            clientInfos.Add("客户端IP[GetHoverTreeIp()]：" + GetHoverTreeIp());
            clientInfos.Add("客户端的操作系统[Request.Browser.Platform]：" + Request.Browser.Platform);
            clientInfos.Add("客户端的操作系统[GetHoverTreeOSName(userAgent)]：" + GetHoverTreeOSName(userAgent));
            clientInfos.Add("是不是win16系统[Request.Browser.Win16]：" + Request.Browser.Win16);
            clientInfos.Add("是不是win32系统[Request.Browser.Win32]：" + Request.Browser.Win32);
            clientInfos.Add("客户端.NET Framework版本：Request.Browser.ClrVersion]：" + Request.Browser.ClrVersion);
            clientInfos.Add("是否支持Java[Request.Browser.JavaApplets]：" + Request.Browser.JavaApplets);

            if (Request.ServerVariables["HTTP_UA_CPU"] == null)
                clientInfos.Add("CPU 类型[Request.ServerVariables[\"HTTP_UA_CPU\"]]:未知");
            else
                clientInfos.Add("CPU 类型[Request.ServerVariables[\"HTTP_UA_CPU\"]]:" + Request.ServerVariables["HTTP_UA_CPU"]);

            clientInfos.Add("UserAgent信息[Request.UserAgent]：" + userAgent);

            ViewBag.ClientInfos = string.Join("<br/>", clientInfos);
            return View();
        }

        /// <summary>
        /// 获取真实IP
        /// </summary>
        /// <returns></returns>
        public string GetHoverTreeIp()
        {
            string result = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = Request.ServerVariables["REMOTE_ADDR"];
            }
            if (null == result || result == String.Empty)
            {
                result = Request.UserHostAddress;
            }
            return result;
        }

        /// <summary>
        /// 根据 User Agent 获取操作系统名称
        /// </summary>
        private string GetHoverTreeOSName(string userAgent)
        {
            string m_hvtOsVersion = "未知";
            if (userAgent.Contains("NT 6.4"))
            {
                m_hvtOsVersion = "Windows 10";
            }
            else
            if (userAgent.Contains("NT 6.3"))
            {
                m_hvtOsVersion = "Windows 8.1";
            }
            else
            if (userAgent.Contains("NT 6.2"))
            {
                m_hvtOsVersion = "Windows 8";
            }
            else
            if (userAgent.Contains("NT 6.1"))
            {
                m_hvtOsVersion = "Windows 7";
            }
            else
            if (userAgent.Contains("NT 6.0"))
            {
                m_hvtOsVersion = "Windows Vista/Server 2008";
            }
            else if (userAgent.Contains("NT 5.2"))
            {
                m_hvtOsVersion = "Windows Server 2003";
            }
            else if (userAgent.Contains("NT 5.1"))
            {
                m_hvtOsVersion = "Windows XP";
            }
            else if (userAgent.Contains("NT 5"))
            {
                m_hvtOsVersion = "Windows 2000";
            }
            else if (userAgent.Contains("NT 4"))
            {
                m_hvtOsVersion = "Windows NT4";
            }
            else if (userAgent.Contains("Me"))
            {
                m_hvtOsVersion = "Windows Me";
            }
            else if (userAgent.Contains("98"))
            {
                m_hvtOsVersion = "Windows 98";
            }
            else if (userAgent.Contains("95"))
            {
                m_hvtOsVersion = "Windows 95";
            }
            else if (userAgent.Contains("Mac"))
            {
                m_hvtOsVersion = "Mac";
            }
            else if (userAgent.Contains("Unix"))
            {
                m_hvtOsVersion = "UNIX";
            }
            else if (userAgent.Contains("Linux"))
            {
                m_hvtOsVersion = "Linux";
            }
            else if (userAgent.Contains("SunOS"))
            {
                m_hvtOsVersion = "SunOS";
            }
            return m_hvtOsVersion;
        }
    }
}