using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IEmployeepayhistoryValidator : IValidator
    {
        Boolean CanCreate(EmployeePayHistoryView view);
        Boolean CanDelete(EmployeePayHistoryView view);
        Boolean CanEdit(EmployeePayHistoryView view);
    }
}
