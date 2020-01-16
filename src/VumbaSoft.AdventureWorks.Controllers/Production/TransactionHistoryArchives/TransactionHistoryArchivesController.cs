using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Production
{
    [Area("Production")]
    public class TransactionHistoryArchivesController : ValidatedController<ITransactionHistoryArchiveValidator, ITransactionHistoryArchiveService>
    {
        public TransactionHistoryArchivesController(ITransactionHistoryArchiveValidator validator, ITransactionHistoryArchiveService service)
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
        public ActionResult Create(TransactionHistoryArchiveView archive)
        {
            if (!Validator.CanCreate(archive))
                return View(archive);

            Service.Create(archive);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<TransactionHistoryArchiveView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<TransactionHistoryArchiveView>(id));
        }

        [HttpPost]
        public ActionResult Edit(TransactionHistoryArchiveView archive)
        {
            if (!Validator.CanEdit(archive))
                return View(archive);

            Service.Edit(archive);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<TransactionHistoryArchiveView>(id));
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
