using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IProductModelIllustrationValidator : IValidator
    {
        Boolean CanCreate(ProductModelIllustrationView view);
        Boolean CanDelete(ProductModelIllustrationView view);
        Boolean CanEdit(ProductModelIllustrationView view);
    }
}
