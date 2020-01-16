using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IDepartmentValidator : IValidator
    {
        Boolean CanCreate(DepartmentView view);
        Boolean CanDelete(DepartmentView view);
        Boolean CanEdit(DepartmentView view);
    }
}
