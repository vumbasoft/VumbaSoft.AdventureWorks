using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IStateProvinceValidator : IValidator
    {
        Boolean CanCreate(StateProvinceView view);
        Boolean CanDelete(StateProvinceView view);
        Boolean CanEdit(StateProvinceView view);
    }
}
