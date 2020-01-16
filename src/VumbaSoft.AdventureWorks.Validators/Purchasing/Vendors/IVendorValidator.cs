using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IVendorValidator : IValidator
    {
        Boolean CanCreate(VendorView view);
        Boolean CanDelete(VendorView view);
        Boolean CanEdit(VendorView view);
    }
}
