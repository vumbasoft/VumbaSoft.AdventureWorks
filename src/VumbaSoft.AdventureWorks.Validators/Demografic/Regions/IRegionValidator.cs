using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IRegionValidator : IValidator
    {
        Boolean CanCreate(RegionView view);
        Boolean CanDelete(RegionView view);
        Boolean CanEdit(RegionView view);
    }
}
