using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ICustomerValidator : IValidator
    {
        Boolean CanCreate(CustomerView view);
        Boolean CanDelete(CustomerView view);
        Boolean CanEdit(CustomerView view);
    }
}
