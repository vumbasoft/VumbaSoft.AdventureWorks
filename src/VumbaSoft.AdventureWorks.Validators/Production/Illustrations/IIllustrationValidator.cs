using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IIllustrationValidator : IValidator
    {
        Boolean CanCreate(IllustrationView view);
        Boolean CanDelete(IllustrationView view);
        Boolean CanEdit(IllustrationView view);
    }
}
