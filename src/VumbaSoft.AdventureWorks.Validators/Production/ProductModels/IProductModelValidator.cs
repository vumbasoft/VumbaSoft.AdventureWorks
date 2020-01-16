using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IProductModelValidator : IValidator
    {
        Boolean CanCreate(ProductModelView view);
        Boolean CanDelete(ProductModelView view);
        Boolean CanEdit(ProductModelView view);
    }
}
