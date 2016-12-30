using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rico.JavaScriptSamples.Controllers
{
    public class JavaScriptSampleController : Controller
    {
        // GET: JavaScriptSample
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// JS 属性
        /// </summary>
        /// <returns></returns>
        public ActionResult JsProperty()
        {
            return View();
        }
        /// <summary>
        /// JS的原型
        /// </summary>
        /// <returns></returns>
        public ActionResult JsPrototype()
        {
            return View();
        }
    }
}