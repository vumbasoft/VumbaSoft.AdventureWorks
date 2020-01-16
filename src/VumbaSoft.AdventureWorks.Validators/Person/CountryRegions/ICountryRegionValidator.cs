using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ICountryRegionValidator : IValidator
    {
        Boolean CanCreate(CountryRegionView view);
        Boolean CanDelete(CountryRegionView view);
        Boolean CanEdit(CountryRegionView view);
    }
}
