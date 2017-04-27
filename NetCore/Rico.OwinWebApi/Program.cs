using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.OwinWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:2002/"))
            {
                Console.WriteLine("http://localhost:2002 服务开启...");
                Console.ReadLine();
            }
        }
    }
}
