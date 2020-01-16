using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IContactCreditCardValidator : IValidator
    {
        Boolean CanCreate(ContactCreditCardView view);
        Boolean CanDelete(ContactCreditCardView view);
        Boolean CanEdit(ContactCreditCardView view);
    }
}
