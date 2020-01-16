using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IEmployeeValidator : IValidator
    {
        Boolean CanCreate(EmployeeView view);
        Boolean CanDelete(EmployeeView view);
        Boolean CanEdit(EmployeeView view);
    }
}
