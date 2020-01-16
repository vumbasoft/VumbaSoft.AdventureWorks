using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IProductCostHistoryValidator : IValidator
    {
        Boolean CanCreate(ProductCostHistoryView view);
        Boolean CanDelete(ProductCostHistoryView view);
        Boolean CanEdit(ProductCostHistoryView view);
    }
}
