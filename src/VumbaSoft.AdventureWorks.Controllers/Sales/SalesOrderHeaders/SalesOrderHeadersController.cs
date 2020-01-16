using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Sales
{
    [Area("Sales")]
    public class SalesOrderHeadersController : ValidatedController<ISalesOrderHeaderValidator, ISalesOrderHeaderService>
    {
        public SalesOrderHeadersController(ISalesOrderHeaderValidator validator, ISalesOrderHeaderService service)
            : base(validator, service)
        {
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(Service.GetViews());
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SalesOrderHeaderView header)
        {
            if (!Validator.CanCreate(header))
                return View(header);

            Service.Create(header);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<SalesOrderHeaderView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<SalesOrderHeaderView>(id));
        }

        [HttpPost]
        public ActionResult Edit(SalesOrderHeaderView header)
        {
            if (!Validator.CanEdit(header))
                return View(header);

            Service.Edit(header);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<SalesOrderHeaderView>(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public RedirectToActionResult DeleteConfirmed(Int32 id)
        {
            Service.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
