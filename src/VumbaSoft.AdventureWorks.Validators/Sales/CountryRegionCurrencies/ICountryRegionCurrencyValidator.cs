using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ICountryRegionCurrencyValidator : IValidator
    {
        Boolean CanCreate(CountryRegionCurrencyView view);
        Boolean CanDelete(CountryRegionCurrencyView view);
        Boolean CanEdit(CountryRegionCurrencyView view);
    }
}
