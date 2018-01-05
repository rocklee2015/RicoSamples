using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S03.OwinOauthServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用WebAPP  安装 Microsoft.Owin.Hosting
            using (WebApp.Start<Startup>("http://localhost:9000"))
            {
                Console.WriteLine("Press [enter] to quit...");
                Console.ReadLine();
            }
        }
    }
}
