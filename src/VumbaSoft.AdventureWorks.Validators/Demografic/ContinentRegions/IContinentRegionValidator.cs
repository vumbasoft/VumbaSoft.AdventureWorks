using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IContinentRegionValidator : IValidator
    {
        Boolean CanCreate(ContinentRegionView view);
        Boolean CanDelete(ContinentRegionView view);
        Boolean CanEdit(ContinentRegionView view);
    }
}
