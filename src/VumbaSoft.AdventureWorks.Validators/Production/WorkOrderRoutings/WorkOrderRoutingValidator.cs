using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class WorkOrderRoutingValidator : BaseValidator, IWorkOrderRoutingValidator
    {
        public WorkOrderRoutingValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(WorkOrderRoutingView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(WorkOrderRoutingView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(WorkOrderRoutingView view)
        {
            return ModelState.IsValid;
        }
    }
}
