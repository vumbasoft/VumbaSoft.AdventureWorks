using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.HumanResources
{
    [Area("HumanResources")]
    public class JobCandidatesController : ValidatedController<IJobCandidateValidator, IJobCandidateService>
    {
        public JobCandidatesController(IJobCandidateValidator validator, IJobCandidateService service)
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
        public ActionResult Create(JobCandidateView candidate)
        {
            if (!Validator.CanCreate(candidate))
                return View(candidate);

            Service.Create(candidate);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<JobCandidateView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<JobCandidateView>(id));
        }

        [HttpPost]
        public ActionResult Edit(JobCandidateView candidate)
        {
            if (!Validator.CanEdit(candidate))
                return View(candidate);

            Service.Edit(candidate);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<JobCandidateView>(id));
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
