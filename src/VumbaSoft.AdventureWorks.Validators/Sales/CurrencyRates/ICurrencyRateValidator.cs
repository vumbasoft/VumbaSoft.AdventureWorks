using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ICurrencyRateValidator : IValidator
    {
        Boolean CanCreate(CurrencyRateView view);
        Boolean CanDelete(CurrencyRateView view);
        Boolean CanEdit(CurrencyRateView view);
    }
}
