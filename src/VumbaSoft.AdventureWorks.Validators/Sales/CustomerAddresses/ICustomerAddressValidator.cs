using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ICustomerAddressValidator : IValidator
    {
        Boolean CanCreate(CustomerAddressView view);
        Boolean CanDelete(CustomerAddressView view);
        Boolean CanEdit(CustomerAddressView view);
    }
}
