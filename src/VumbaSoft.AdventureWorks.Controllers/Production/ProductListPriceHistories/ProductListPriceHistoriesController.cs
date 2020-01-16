using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Production
{
    [Area("Production")]
    public class ProductListPriceHistoriesController : ValidatedController<IProductListPriceHistoryValidator, IProductListPriceHistoryService>
    {
        public ProductListPriceHistoriesController(IProductListPriceHistoryValidator validator, IProductListPriceHistoryService service)
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
        public ActionResult Create(ProductListPriceHistoryView history)
        {
            if (!Validator.CanCreate(history))
                return View(history);

            Service.Create(history);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductListPriceHistoryView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductListPriceHistoryView>(id));
        }

        [HttpPost]
        public ActionResult Edit(ProductListPriceHistoryView history)
        {
            if (!Validator.CanEdit(history))
                return View(history);

            Service.Edit(history);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductListPriceHistoryView>(id));
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
