using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ric.S01.MvcDemo.Controllers
{
    public class S03PostmanController : Controller
    {
        // GET: Postman
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestUrlEncode(string text)
        {
            return Content(text);
        }

        public ActionResult TestUrlUnEncode(string text)
        {
            return Content(text);
        }
    }
}