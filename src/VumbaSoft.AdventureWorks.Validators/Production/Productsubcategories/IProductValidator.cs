using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IProductValidator : IValidator
    {
        Boolean CanCreate(ProductView view);
        Boolean CanDelete(ProductView view);
        Boolean CanEdit(ProductView view);
    }
}
