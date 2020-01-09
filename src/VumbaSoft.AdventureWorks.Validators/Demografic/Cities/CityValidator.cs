using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class CityValidator : BaseValidator, ICityValidator
    {
        public CityValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CityView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(CityView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(CityView view)
        {
            return ModelState.IsValid;
        }
    }
}
