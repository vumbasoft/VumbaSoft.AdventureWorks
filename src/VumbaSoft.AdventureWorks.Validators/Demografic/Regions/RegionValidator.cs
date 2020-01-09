using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class RegionValidator : BaseValidator, IRegionValidator
    {
        public RegionValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(RegionView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(RegionView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(RegionView view)
        {
            return ModelState.IsValid;
        }
    }
}
