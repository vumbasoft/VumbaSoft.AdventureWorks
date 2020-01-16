using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IPurchaseOrderDetailValidator : IValidator
    {
        Boolean CanCreate(PurchaseOrderDetailView view);
        Boolean CanDelete(PurchaseOrderDetailView view);
        Boolean CanEdit(PurchaseOrderDetailView view);
    }
}
