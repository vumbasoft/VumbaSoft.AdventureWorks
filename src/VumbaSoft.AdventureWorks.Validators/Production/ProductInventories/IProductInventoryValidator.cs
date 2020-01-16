using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IProductInventoryValidator : IValidator
    {
        Boolean CanCreate(ProductInventoryView view);
        Boolean CanDelete(ProductInventoryView view);
        Boolean CanEdit(ProductInventoryView view);
    }
}
