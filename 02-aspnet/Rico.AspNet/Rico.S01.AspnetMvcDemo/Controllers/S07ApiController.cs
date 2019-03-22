using Rico.S01.AspnetMvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rico.S01.AspnetMvcDemo.Controllers
{
    public class S07ApiController : Controller
    {
        // GET: S07Api
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult UserList()
        {
            return Json(new List<User>() {
                 new User(){  UserName="ricolee", UserEmail="rocklee@163.com"},
                 new User(){  UserName="kenan", UserEmail="kenan@163.com"},
            },JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login()
        {
            return Json(new { result="success",code=0}, JsonRequestBehavior.AllowGet);
        }
    }
}