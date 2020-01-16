using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IPurchaseOrderHeaderValidator : IValidator
    {
        Boolean CanCreate(PurchaseOrderHeaderView view);
        Boolean CanDelete(PurchaseOrderHeaderView view);
        Boolean CanEdit(PurchaseOrderHeaderView view);
    }
}
