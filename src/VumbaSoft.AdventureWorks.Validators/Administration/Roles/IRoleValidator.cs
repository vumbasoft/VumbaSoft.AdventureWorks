using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IRoleValidator : IValidator
    {
        Boolean CanCreate(RoleView view);
        Boolean CanEdit(RoleView view);
    }
}
