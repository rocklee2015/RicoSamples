using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rico.BootstrapSamples.Models;

namespace Rico.BootstrapSamples.Controllers
{
    public class BootstrapController : Controller
    {
        // GET: Bootstrap
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Export()
        {
            return View();
        }
        public JsonResult GetDepartment(int limit, int offset, string departmentname, string statu)
        {
            var depts = new List<DepartmentModel>();
            for (var i = 0; i < 50; i++)
            {
                var dept = new DepartmentModel();
                dept.ID = Guid.NewGuid().ToString();
                dept.Name = "销售部" + i;
                dept.Level = i.ToString();
                dept.Desc = "暂无描述信息";
                depts.Add(dept);
            }

            return Json(depts, JsonRequestBehavior.AllowGet);
        }
    }
}