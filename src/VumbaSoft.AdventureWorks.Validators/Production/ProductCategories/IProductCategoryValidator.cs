using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IProductCategoryValidator : IValidator
    {
        Boolean CanCreate(ProductCategoryView view);
        Boolean CanDelete(ProductCategoryView view);
        Boolean CanEdit(ProductCategoryView view);
    }
}
