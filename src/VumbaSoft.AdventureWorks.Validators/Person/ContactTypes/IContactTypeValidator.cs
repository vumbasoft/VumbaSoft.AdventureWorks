using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IContactTypeValidator : IValidator
    {
        Boolean CanCreate(ContactTypeView view);
        Boolean CanDelete(ContactTypeView view);
        Boolean CanEdit(ContactTypeView view);
    }
}
