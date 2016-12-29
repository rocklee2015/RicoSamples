using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rico.CQRS.Commands;
using Rico.CQRS.Configuration;
using Rico.CQRS.Exceptions;
using Rico.CQRS.Reporting;

namespace Rico.CQRS.WebTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Model = ServiceLocator.ReportDatabase.GetItems();
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Delete(Guid id)
        {
            var item = ServiceLocator.ReportDatabase.GetById(id);
            ServiceLocator.CommandBus.Send(new DeleteItemCommand(item.Id, item.Version));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(DiaryItemDto item)
        {
            ServiceLocator.CommandBus.Send(new CreateItemCommand(Guid.NewGuid(), item.Title, item.Description, -1, item.From, item.To));

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var item = ServiceLocator.ReportDatabase.GetById(id);
            var model = new DiaryItemDto()
            {
                Description = item.Description,
                From = item.From,
                Id = item.Id,
                Title = item.Title,
                To = item.To,
                Version = item.Version
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DiaryItemDto item)
        {
            try
            {
                ServiceLocator.CommandBus.Send(new ChangeItemCommand(item.Id, item.Title, item.Description, item.From, item.To, item.Version));
            }
            catch (ConcurrencyException err)
            {

                ViewBag.error = err.Message;
                ModelState.AddModelError("", err.Message);
                return View();

            }

            return RedirectToAction("Index");
        }
    }
}
