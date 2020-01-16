using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IVendorAddressValidator : IValidator
    {
        Boolean CanCreate(VendorAddressView view);
        Boolean CanDelete(VendorAddressView view);
        Boolean CanEdit(VendorAddressView view);
    }
}
