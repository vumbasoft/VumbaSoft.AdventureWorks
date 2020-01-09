using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class CountryValidator : BaseValidator, ICountryValidator
    {
        public CountryValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CountryView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(CountryView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(CountryView view)
        {
            return ModelState.IsValid;
        }
    }
}
