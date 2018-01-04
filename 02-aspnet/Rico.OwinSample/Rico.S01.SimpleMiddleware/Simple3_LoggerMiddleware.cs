using log4net;
using Microsoft.Owin;
using Owin;
using Rico.S01.SimpleMiddleware;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S01.SimpleMiddleware
{
    public class Simple3_LoggerMiddleware : OwinMiddleware
    {
        LoggerMiddlewareParameters _parameter;
        public Simple3_LoggerMiddleware(OwinMiddleware next, LoggerMiddlewareParameters parameter) : base(next)
        {
            _parameter = parameter;
        }
        public override Task Invoke(IOwinContext c)
        {
            if (Next != null)
            {
                try
                {
                    var cookie = c.Request.Cookies.ToList();
                    string allcookie = string.Empty;
                    string allenvi = string.Empty;
                    foreach (var cok in cookie)
                    {
                        allcookie += cok.Key + "---------------" + cok.Value + "<br />";
                        c.Environment.Add(cok.Key, cok.Value);
                    }

                    foreach (var envi in c.Environment)
                    {
                        allenvi += envi.Key + "---------------" + envi.Value + "<br />";
                    }
                    _parameter.logs.Info(allenvi);

                    var msg = Encoding.UTF8.GetBytes(allcookie + "<br /><br /><br /><br /><br /><br />" + allenvi);
                    c.Response.ContentType = "text/html; charset=utf-8";
                    c.Response.Write(msg, 0, msg.Length);



                    //处理操作
                    return Next.Invoke(c);
                }
                catch (Exception ex)
                {
                    _parameter.logs.Error(ex.Message);
                }
            }
            return Task.FromResult<int>(0);
        }

    }
    public class LoggerMiddlewareParameters
    {
        public ILog logs { get; }

        public string siteName { get; set; }
        // public LYMOptions lymOptions { get; set; }
        public LoggerMiddlewareParameters()
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Log4Net.config"));
            this.logs = LogManager.GetLogger("CustomMiddlewareParameters");
            // this.lymOptions = new LYMOptions();
        }

        internal void Validate()
        {
            if (siteName == null)
            {
                throw new ArgumentException("参数siteName不能设置为Null");
            }
            //if (lymOptions == null)
            //{
            //    throw new ArgumentException("参数cookieOptions不能设置为Null");
        }

    }
    public static class LoggerMiddlewareExtentions
    {
        public static IAppBuilder UseLoggerMiddleware(this IAppBuilder builder, LoggerMiddlewareParameters customParmeters)
        {
            try
            {
                customParmeters.Validate();
                builder.Use<Simple3_LoggerMiddleware>(customParmeters);
            }
            catch (Exception ex)
            {
                customParmeters.logs.Error(ex.Message);
            }
            return builder;
        }


    }

}

