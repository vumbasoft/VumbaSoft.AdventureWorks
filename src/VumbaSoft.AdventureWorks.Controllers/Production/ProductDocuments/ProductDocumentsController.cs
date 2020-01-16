using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Production
{
    [Area("Production")]
    public class ProductDocumentsController : ValidatedController<IProductDocumentValidator, IProductDocumentService>
    {
        public ProductDocumentsController(IProductDocumentValidator validator, IProductDocumentService service)
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
        public ActionResult Create(ProductDocumentView document)
        {
            if (!Validator.CanCreate(document))
                return View(document);

            Service.Create(document);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductDocumentView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductDocumentView>(id));
        }

        [HttpPost]
        public ActionResult Edit(ProductDocumentView document)
        {
            if (!Validator.CanEdit(document))
                return View(document);

            Service.Edit(document);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductDocumentView>(id));
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
