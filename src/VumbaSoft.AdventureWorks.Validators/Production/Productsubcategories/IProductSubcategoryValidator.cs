using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IProductSubcategoryValidator : IValidator
    {
        Boolean CanCreate(ProductSubcategoryView view);
        Boolean CanDelete(ProductSubcategoryView view);
        Boolean CanEdit(ProductSubcategoryView view);
    }
}
