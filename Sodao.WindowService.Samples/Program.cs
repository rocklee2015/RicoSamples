using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodao.WindowService.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.FriendlyName);
                switch (args[0])
                {
                    case "-i":
                        ManagedInstallerClass.InstallHelper(new string[] { path });
                        break;
                    case "-u":
                        ManagedInstallerClass.InstallHelper(new string[] { "/u", path });
                        break;
                }
            }
            else
            {
                System.ServiceProcess.ServiceBase[] servicesToRun;
                servicesToRun = new System.ServiceProcess.ServiceBase[] { new MainService() };
                System.ServiceProcess.ServiceBase.Run(servicesToRun);
            }
        }
    }
}
