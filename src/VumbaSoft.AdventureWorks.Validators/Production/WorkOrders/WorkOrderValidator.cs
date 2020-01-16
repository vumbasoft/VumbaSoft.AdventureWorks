using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class WorkOrderValidator : BaseValidator, IWorkOrderValidator
    {
        public WorkOrderValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(WorkOrderView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(WorkOrderView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(WorkOrderView view)
        {
            return ModelState.IsValid;
        }
    }
}
