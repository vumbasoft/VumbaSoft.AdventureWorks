using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class VendorValidator : BaseValidator, IVendorValidator
    {
        public VendorValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(VendorView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(VendorView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(VendorView view)
        {
            return ModelState.IsValid;
        }
    }
}
