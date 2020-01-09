using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ILocalityValidator : IValidator
    {
        Boolean CanCreate(LocalityView view);
        Boolean CanDelete(LocalityView view);
        Boolean CanEdit(LocalityView view);
    }
}
