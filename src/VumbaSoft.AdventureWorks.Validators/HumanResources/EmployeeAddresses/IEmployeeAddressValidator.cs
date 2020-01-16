using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IEmployeeAddressValidator : IValidator
    {
        Boolean CanCreate(EmployeeAddressView view);
        Boolean CanDelete(EmployeeAddressView view);
        Boolean CanEdit(EmployeeAddressView view);
    }
}
