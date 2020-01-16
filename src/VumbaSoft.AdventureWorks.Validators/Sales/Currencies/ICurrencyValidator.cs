using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ICurrencyValidator : IValidator
    {
        Boolean CanCreate(CurrencyView view);
        Boolean CanDelete(CurrencyView view);
        Boolean CanEdit(CurrencyView view);
    }
}
