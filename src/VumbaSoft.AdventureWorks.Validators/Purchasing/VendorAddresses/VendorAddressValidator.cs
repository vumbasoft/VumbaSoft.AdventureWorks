using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class VendorAddressValidator : BaseValidator, IVendorAddressValidator
    {
        public VendorAddressValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(VendorAddressView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(VendorAddressView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(VendorAddressView view)
        {
            return ModelState.IsValid;
        }
    }
}
