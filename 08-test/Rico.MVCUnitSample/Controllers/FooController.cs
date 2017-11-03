using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rico.MVCUnitSample.Models;

namespace Rico.MVCUnitSample.Controllers
{
    public class FooController : Controller
    {
        private readonly IFooRepository _fooRepository;

        public FooController(IFooRepository fooRepository)
        {
            _fooRepository = fooRepository;
        }

        public ViewResult Index()
        {
            var model = _fooRepository.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _fooRepository.GetSingle(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = _fooRepository.GetSingle(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [ActionName("Edit"), HttpPost]
        public ActionResult Eidt_Post(Foo foo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _fooRepository.Edit(foo);
                    _fooRepository.Save();
                    return RedirectToAction("Details", new { id = foo.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "出错了：" + ex.Message);
                }
            }
            return View(foo);
        }

        public ActionResult Create()
        {
            return View();
        }

        [ActionName("Create"), HttpPost]
        public ActionResult Create_Post(Foo foo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _fooRepository.Add(foo);
                    _fooRepository.Save();
                    return RedirectToAction("Details", new { id = foo.Id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "出错了：" + ex.Message);
                }
            }
            return View(foo);
        }

        public ActionResult Delete(int id)
        {
            var model = _fooRepository.GetSingle(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [ActionName("Delete"), HttpPost]
        public ActionResult Delete_Post(int id)
        {
            var model = _fooRepository.GetSingle(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            _fooRepository.Delete(model);
            _fooRepository.Save();
            return RedirectToAction("Index");
        }
    }

}