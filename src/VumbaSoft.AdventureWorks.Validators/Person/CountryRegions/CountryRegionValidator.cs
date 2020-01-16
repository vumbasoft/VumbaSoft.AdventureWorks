using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class CountryRegionValidator : BaseValidator, ICountryRegionValidator
    {
        public CountryRegionValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CountryRegionView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(CountryRegionView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(CountryRegionView view)
        {
            return ModelState.IsValid;
        }
    }
}
