using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class CustomerAddressValidator : BaseValidator, ICustomerAddressValidator
    {
        public CustomerAddressValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CustomerAddressView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(CustomerAddressView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(CustomerAddressView view)
        {
            return ModelState.IsValid;
        }
    }
}
