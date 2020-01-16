using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Production
{
    [Area("Production")]
    public class ProductModelProductDescriptionCulturesController : ValidatedController<IProductModelProductDescriptionCultureValidator, IProductModelProductDescriptionCultureService>
    {
        public ProductModelProductDescriptionCulturesController(IProductModelProductDescriptionCultureValidator validator, IProductModelProductDescriptionCultureService service)
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
        public ActionResult Create(ProductModelProductDescriptionCultureView culture)
        {
            if (!Validator.CanCreate(culture))
                return View(culture);

            Service.Create(culture);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductModelProductDescriptionCultureView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductModelProductDescriptionCultureView>(id));
        }

        [HttpPost]
        public ActionResult Edit(ProductModelProductDescriptionCultureView culture)
        {
            if (!Validator.CanEdit(culture))
                return View(culture);

            Service.Edit(culture);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductModelProductDescriptionCultureView>(id));
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
