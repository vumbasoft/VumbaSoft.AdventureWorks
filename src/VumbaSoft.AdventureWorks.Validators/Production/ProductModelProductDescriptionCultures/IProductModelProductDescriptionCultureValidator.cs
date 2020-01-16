using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IProductModelProductDescriptionCultureValidator : IValidator
    {
        Boolean CanCreate(ProductModelProductDescriptionCultureView view);
        Boolean CanDelete(ProductModelProductDescriptionCultureView view);
        Boolean CanEdit(ProductModelProductDescriptionCultureView view);
    }
}
