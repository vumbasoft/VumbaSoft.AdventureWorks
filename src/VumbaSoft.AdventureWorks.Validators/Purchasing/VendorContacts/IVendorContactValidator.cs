using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IVendorContactValidator : IValidator
    {
        Boolean CanCreate(VendorContactView view);
        Boolean CanDelete(VendorContactView view);
        Boolean CanEdit(VendorContactView view);
    }
}
