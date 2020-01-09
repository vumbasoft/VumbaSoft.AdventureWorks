using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ContinentRegionValidator : BaseValidator, IContinentRegionValidator
    {
        public ContinentRegionValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ContinentRegionView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ContinentRegionView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ContinentRegionView view)
        {
            return ModelState.IsValid;
        }
    }
}
