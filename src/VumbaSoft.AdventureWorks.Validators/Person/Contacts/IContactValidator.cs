using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IContactValidator : IValidator
    {
        Boolean CanCreate(ContactView view);
        Boolean CanDelete(ContactView view);
        Boolean CanEdit(ContactView view);
    }
}
