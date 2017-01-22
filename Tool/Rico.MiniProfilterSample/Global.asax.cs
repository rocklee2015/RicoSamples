using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;

namespace Rico.MiniProfilterSample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //只有用户名为admin才能查看分析
            //MiniProfiler.Settings.Results_Authorize = request =>
            //{
            //    string name = request.Cookies["name"] == null ? "" : request.Cookies["name"].Value;
            //    if (name.Equals("admin"))
            //        return true;
            //    else
            //        return false;
            //};

            MiniProfilerEF6.Initialize();

        }
        protected void Application_BeginRequest()
        {
            if (Request.IsLocal)
            {
                MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }
    }
}
