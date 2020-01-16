using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IEmployeedepartmenthistoryValidator : IValidator
    {
        Boolean CanCreate(EmployeeDepartmentHistoryView view);
        Boolean CanDelete(EmployeeDepartmentHistoryView view);
        Boolean CanEdit(EmployeeDepartmentHistoryView view);
    }
}
