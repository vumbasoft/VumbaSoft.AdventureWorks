using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class AdventureworkFacilityValidator : BaseValidator, IAdventureworkFacilityValidator
    {
        public AdventureworkFacilityValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(AdventureworkFacilityView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(AdventureworkFacilityView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(AdventureworkFacilityView view)
        {
            return ModelState.IsValid;
        }
    }
}
