using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IDistrictValidator : IValidator
    {
        Boolean CanCreate(DistrictView view);
        Boolean CanDelete(DistrictView view);
        Boolean CanEdit(DistrictView view);
    }
}
