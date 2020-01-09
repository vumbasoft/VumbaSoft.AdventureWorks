using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IAdventureworkFacilityValidator : IValidator
    {
        Boolean CanCreate(AdventureworkFacilityView view);
        Boolean CanDelete(AdventureworkFacilityView view);
        Boolean CanEdit(AdventureworkFacilityView view);
    }
}
