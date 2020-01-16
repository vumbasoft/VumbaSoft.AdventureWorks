using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ILocationValidator : IValidator
    {
        Boolean CanCreate(LocationView view);
        Boolean CanDelete(LocationView view);
        Boolean CanEdit(LocationView view);
    }
}
