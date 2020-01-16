using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IWorkOrderRoutingValidator : IValidator
    {
        Boolean CanCreate(WorkOrderRoutingView view);
        Boolean CanDelete(WorkOrderRoutingView view);
        Boolean CanEdit(WorkOrderRoutingView view);
    }
}
