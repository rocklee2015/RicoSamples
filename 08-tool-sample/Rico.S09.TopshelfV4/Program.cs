using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
using Topshelf;

namespace Rico.S09.TopshelfV4
{
    class Program
    {
        static void Main(string[] args)
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);

            HostFactory.Run(x =>
            {
                x.Service<TownCrier>();
                x.RunAsLocalSystem();

                x.SetDescription("简单模式 Topshelf Host服务的描述");
                x.SetDisplayName("Stuff简单模式");
                x.SetServiceName("Stuff简单模式");
            });

        }
    }
}
