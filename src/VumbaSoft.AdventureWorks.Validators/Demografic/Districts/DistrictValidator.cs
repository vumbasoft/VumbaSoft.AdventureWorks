using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class DistrictValidator : BaseValidator, IDistrictValidator
    {
        public DistrictValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(DistrictView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(DistrictView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(DistrictView view)
        {
            return ModelState.IsValid;
        }
    }
}
