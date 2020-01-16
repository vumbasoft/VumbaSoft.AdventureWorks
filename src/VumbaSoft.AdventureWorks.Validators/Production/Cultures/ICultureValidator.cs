using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ICultureValidator : IValidator
    {
        Boolean CanCreate(CultureView view);
        Boolean CanDelete(CultureView view);
        Boolean CanEdit(CultureView view);
    }
}
