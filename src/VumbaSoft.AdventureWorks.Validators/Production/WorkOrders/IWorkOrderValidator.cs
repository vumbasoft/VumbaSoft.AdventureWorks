using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IWorkOrderValidator : IValidator
    {
        Boolean CanCreate(WorkOrderView view);
        Boolean CanDelete(WorkOrderView view);
        Boolean CanEdit(WorkOrderView view);
    }
}
