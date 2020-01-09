using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ICityValidator : IValidator
    {
        Boolean CanCreate(CityView view);
        Boolean CanDelete(CityView view);
        Boolean CanEdit(CityView view);
    }
}
