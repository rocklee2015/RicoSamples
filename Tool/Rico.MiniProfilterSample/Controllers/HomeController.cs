using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rico.EF6Samples;

namespace Rico.MiniProfilterSample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (RicoDbContext dbContext = new RicoDbContext())
            {
                ViewBag.data = dbContext.Students.ToList();
            }

            return View();
        }
    }
}