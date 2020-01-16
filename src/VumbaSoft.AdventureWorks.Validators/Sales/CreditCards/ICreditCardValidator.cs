using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ICreditCardValidator : IValidator
    {
        Boolean CanCreate(CreditCardView view);
        Boolean CanDelete(CreditCardView view);
        Boolean CanEdit(CreditCardView view);
    }
}
