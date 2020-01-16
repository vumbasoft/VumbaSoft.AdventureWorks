using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Production
{
    [Area("Production")]
    public class ProductModelIllustrationsController : ValidatedController<IProductModelIllustrationValidator, IProductModelIllustrationService>
    {
        public ProductModelIllustrationsController(IProductModelIllustrationValidator validator, IProductModelIllustrationService service)
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
        public ActionResult Create(ProductModelIllustrationView illustration)
        {
            if (!Validator.CanCreate(illustration))
                return View(illustration);

            Service.Create(illustration);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductModelIllustrationView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductModelIllustrationView>(id));
        }

        [HttpPost]
        public ActionResult Edit(ProductModelIllustrationView illustration)
        {
            if (!Validator.CanEdit(illustration))
                return View(illustration);

            Service.Edit(illustration);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductModelIllustrationView>(id));
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
