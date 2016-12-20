using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rico.MetronicUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        #region ==UI Element
        public ActionResult ui_general()
        {
            return View();
        }
        public ActionResult ui_buttons()
        {
            return View();
        }
        public ActionResult ui_tabs_accordions()
        {
            return View();
        }
        public ActionResult ui_sliders()
        {
            return View();
        }
        public ActionResult ui_tiles()
        {
            return View();
        }
        public ActionResult ui_typography()
        {
            return View();
        }
        public ActionResult ui_tree()
        {
            return View();
        }
        public ActionResult ui_nestable()
        {
            return View();
        }
        #endregion
        #region ==Form
        public ActionResult form_layout()
        {
            return View();
        }
        public ActionResult form_samples()
        {
            return View();
        }
        public ActionResult form_component()
        {
            return View();
        }
        public ActionResult form_wizard()
        {
            return View();
        }
        public ActionResult form_validation()
        {
            return View();
        }
        public ActionResult form_fileupload()
        {
            return View();
        }
        public ActionResult form_dropzone()
        {
            return View();
        }
        #endregion
        #region ==DataTable
        public ActionResult table_basic()
        {
            return View();
        }
        public ActionResult table_managed()
        {
            return View();
        }
        public ActionResult table_editable()
        {
            return View();
        }

        #endregion
        #region ==Extra
        public ActionResult extra_profile()
        {
            return View();
        }
        public ActionResult extra_faq()
        {
            return View();
        }
        public ActionResult extra_search()
        {
            return View();
        }
        public ActionResult extra_invoice()
        {
            return View();
        }
        public ActionResult extra_pricing_table()
        {
            return View();
        }
        public ActionResult extra_404()
        {
            return View();
        }
        public ActionResult extra_500()
        {
            return View();
        }
        public ActionResult extra_blank()
        {
            return View();
        }
        public ActionResult extra_full_width()
        {
            return View();
        }
        #endregion
    }
}