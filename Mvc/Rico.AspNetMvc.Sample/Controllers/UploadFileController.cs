using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rico.AspNetMvc.Sample.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: UploadFile
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFileByHttpPostedFileBase(HttpPostedFileBase httpPostedFileBase)
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult UploadFileByHttpPostedFile(HttpPostedFile httpPostedFile)
        {
            return View("Index");
        }
    }
}