using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ProductVendorValidator : BaseValidator, IProductVendorValidator
    {
        public ProductVendorValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductVendorView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ProductVendorView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ProductVendorView view)
        {
            return ModelState.IsValid;
        }
    }
}
