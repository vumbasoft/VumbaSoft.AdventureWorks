using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class VendorContactValidator : BaseValidator, IVendorContactValidator
    {
        public VendorContactValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(VendorContactView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(VendorContactView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(VendorContactView view)
        {
            return ModelState.IsValid;
        }
    }
}
