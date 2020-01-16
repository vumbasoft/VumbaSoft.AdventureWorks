using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class AddressValidator : BaseValidator, IAddressValidator
    {
        public AddressValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(AddressView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(AddressView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(AddressView view)
        {
            return ModelState.IsValid;
        }
    }
}
