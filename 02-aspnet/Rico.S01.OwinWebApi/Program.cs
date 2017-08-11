using System;
using Microsoft.Owin.Hosting;

namespace Rico.S01.OwinWebApi
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
