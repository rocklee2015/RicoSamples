using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//*****log4net.config文件要配置始终输出哦，不然写不成功的！*****
[assembly: log4net.Config.XmlConfigurator(ConfigFile = @"config\log4net.config", Watch = true)]
namespace Rico.Log4net.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = AppDomain.CurrentDomain.BaseDirectory + @"\config\log4net.config";
            //log4net.Config.XmlConfigurator.Configure(new FileInfo(path));

            ILog log = log4net.LogManager.GetLogger(typeof(Program));
            log.Error("aa");
            log.Info("bb");
            log.Fatal("dd");
            log.Debug("ff");
        }
    }
}
