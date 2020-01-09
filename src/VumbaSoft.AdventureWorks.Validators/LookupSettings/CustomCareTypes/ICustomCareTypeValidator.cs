using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ICustomCareTypeValidator : IValidator
    {
        Boolean CanCreate(CustomCareTypeView view);
        Boolean CanDelete(CustomCareTypeView view);
        Boolean CanEdit(CustomCareTypeView view);
    }
}
