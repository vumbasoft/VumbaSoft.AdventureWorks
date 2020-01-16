using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IProductDescriptionValidator : IValidator
    {
        Boolean CanCreate(ProductDescriptionView view);
        Boolean CanDelete(ProductDescriptionView view);
        Boolean CanEdit(ProductDescriptionView view);
    }
}
