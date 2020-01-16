using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IAddressValidator : IValidator
    {
        Boolean CanCreate(AddressView view);
        Boolean CanDelete(AddressView view);
        Boolean CanEdit(AddressView view);
    }
}
