using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class CountryRegionCurrencyValidator : BaseValidator, ICountryRegionCurrencyValidator
    {
        public CountryRegionCurrencyValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CountryRegionCurrencyView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(CountryRegionCurrencyView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(CountryRegionCurrencyView view)
        {
            return ModelState.IsValid;
        }
    }
}
