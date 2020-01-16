using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IProductVendorValidator : IValidator
    {
        Boolean CanCreate(ProductVendorView view);
        Boolean CanDelete(ProductVendorView view);
        Boolean CanEdit(ProductVendorView view);
    }
}
