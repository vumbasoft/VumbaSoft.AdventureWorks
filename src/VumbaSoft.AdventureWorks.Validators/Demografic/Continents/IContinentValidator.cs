using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IContinentValidator : IValidator
    {
        Boolean CanCreate(ContinentView view);
        Boolean CanDelete(ContinentView view);
        Boolean CanEdit(ContinentView view);
    }
}
