using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rico.S01.AspnetMvcDemo.Controllers
{
    public class S04MarkdownCodeController : Controller
    {
        // GET: S04MarkdownCode
        public ActionResult HighLight()
        {
            return View();
        }

        public ActionResult MarkdonwFile()
        {
            var mk = AppDomain.CurrentDomain.BaseDirectory + "Content/markdown/demo.md";
            return File(mk,"text/plain");
        }
    }
}