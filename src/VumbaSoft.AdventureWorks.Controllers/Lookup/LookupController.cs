using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Components.Lookups;
using VumbaSoft.AdventureWorks.Components.Mvc;
using VumbaSoft.AdventureWorks.Components.Security;
using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using NonFactors.Mvc.Lookup;
using System;

namespace VumbaSoft.AdventureWorks.Controllers
{
    [AllowUnauthorized]
    public class LookupController : BaseController
    {
        private IUnitOfWork UnitOfWork { get; }

        public LookupController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [NonAction]
        public virtual JsonResult GetData(MvcLookup lookup, LookupFilter filter)
        {
            lookup.Filter = filter;

            return Json(lookup.GetData());
        }

        [AjaxOnly]
        public JsonResult Role(LookupFilter filter)
        {
            return GetData(new MvcLookup<Role, RoleView>(UnitOfWork), filter);
        }

        protected override void Dispose(Boolean disposing)
        {
            UnitOfWork.Dispose();

            base.Dispose(disposing);
        }
    }
}
