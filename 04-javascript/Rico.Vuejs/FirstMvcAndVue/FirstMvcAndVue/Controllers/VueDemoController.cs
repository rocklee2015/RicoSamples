using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcAndVue.Controllers
{
    public class VueDemoController : Controller
    {
        // GET: VueDemo
        public ActionResult First()
        {
            return View();
        }
        public ActionResult FormDemo()
        {
            return View();
        }
        public ActionResult VueComponent()
        {
            return View();
        }
    }
}