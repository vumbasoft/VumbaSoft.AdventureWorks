using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IProductListPriceHistoryValidator : IValidator
    {
        Boolean CanCreate(ProductListPriceHistoryView view);
        Boolean CanDelete(ProductListPriceHistoryView view);
        Boolean CanEdit(ProductListPriceHistoryView view);
    }
}
