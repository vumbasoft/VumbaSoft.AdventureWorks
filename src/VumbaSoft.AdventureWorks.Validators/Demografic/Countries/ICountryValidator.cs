using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ICountryValidator : IValidator
    {
        Boolean CanCreate(CountryView view);
        Boolean CanDelete(CountryView view);
        Boolean CanEdit(CountryView view);
    }
}
