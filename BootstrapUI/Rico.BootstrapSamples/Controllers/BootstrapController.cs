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
            var depts = DataSourceManage.GetDepartments();

            return Json(depts, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDepartmentGrid(int limit, int offset, string departmentname, string statu)
        {
            var depts = DataSourceManage.GetDepartments();
            var total = depts.Count;
            var rows = depts.Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GroupColumns()
        {
            return View();
        }

        public JsonResult GetReport(int limit, int offset)
        {
            var reports = DataSourceManage.GetReports();
            var total = reports.Count;
            var rows = reports.Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditTable()
        {
            return View();
        }
        public JsonResult Edit(string strJson)
        {
            //反序列化之后更新

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
    }
}