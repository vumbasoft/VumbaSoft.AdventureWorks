using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IProvinceValidator : IValidator
    {
        Boolean CanCreate(ProvinceView view);
        Boolean CanDelete(ProvinceView view);
        Boolean CanEdit(ProvinceView view);
    }
}
