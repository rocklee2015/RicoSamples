using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rico.AceAdminUI.Controllers
{
    public class AceAdminController : Controller
    { // GET: Ace
        public ActionResult Index()
        {
            return View();
        }
        #region==字体排版
        public ActionResult typography()
        {
            return View();
        }
        #endregion
        #region ===UI组件
        public ActionResult top_menu()
        {
            return View();
        }
        public ActionResult elements()
        {
            return View();
        }
        public ActionResult buttons()
        {
            return View();
        }
        public ActionResult treeview()
        {
            return View();
        }
        public ActionResult jquery_ui()
        {
            return View();
        }
        public ActionResult nestable_list()
        {
            return View();
        }

        #endregion
        #region ==表格
        public ActionResult tables()
        {
            return View();
        }
        public ActionResult jqgrid()
        {
            return View();
        }
        public ActionResult jqgrid_local()
        {
            return View();
        }
        public ActionResult jqgrid_json()
        {
            return View();
        }
        [HttpGet]
        public JsonResult jsondata()
        {
            //Request.QueryString["filters"]
            //"{\"groupOp\":\"AND\",\"rules\":[{\"field\":\"name\",\"op\":\"cn\",\"data\":\"3\"}]}"
            var pageIndex = int.Parse(Request.QueryString["page"]);
            var pageSize = int.Parse(Request.QueryString["rows"]);
            var data = new List<dynamic>();
            for (int i = 35; i > 0; i--)
            {
                data.Add(new
                { id = i.ToString(), name = "Desktop Computer", note = "note", stock = "Yes", ship = "FedEx", sdate = "2007-12-03" }
               );
            }
            var rows = data.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var result = new
            {
                id = "id", //相当于设置主键
                rows = rows,    //Json数据
                total = Math.Ceiling(((double)data.Count) / (double)pageSize),   //总页数
                page = pageIndex,  //当前页
                records = data.Count,//总记录数
                repeatitems =
            false

            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion
        #region ===表单
        public ActionResult form_elements()
        {
            return View();
        }
        public ActionResult form_wizard()
        {
            return View();
        }
        /// <summary>
        /// jQueryValidate插件
        /// </summary>
        /// <returns></returns>
        public ActionResult form_jqueryvalidate()
        {
            return View();
        }
        /// <summary>
        /// validation_engine插件
        /// </summary>
        /// <returns></returns>
        public ActionResult form_validation_engine()
        {
            return View();
        }

        public ActionResult wysiwyg()
        {
            return View();
        }
        public ActionResult dropzone()
        {
            return View();
        }

        #endregion
        #region==widgets
        public ActionResult widgets()
        {
            return View();
        }
        #endregion
        public ActionResult calendar()
        {
            return View();
        }
        public ActionResult gallery()
        {
            return View();
        }
        #region ====更多页面
        public ActionResult profile()
        {
            return View();
        }
        public ActionResult inbox()
        {
            return View();
        }
        public ActionResult pricing()
        {
            return View();
        }
        public ActionResult invoice()
        {
            return View();
        }
        public ActionResult timeline()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        #endregion

        #region ======其它页面
        public ActionResult faq()
        {
            return View();
        }
        public ActionResult error_404()
        {
            return View();
        }
        public ActionResult error_500()
        {
            return View();
        }
        public ActionResult grid()
        {
            return View();
        }
        public ActionResult blank()
        {
            return View();
        }
        #endregion
        public ActionResult lhgdialog()
        {
            return View();
        }
        public ActionResult lhgdialogForm()
        {
            return View();
        }
    }
}