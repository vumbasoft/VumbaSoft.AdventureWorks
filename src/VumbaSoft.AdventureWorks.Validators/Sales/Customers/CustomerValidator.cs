using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class CustomerValidator : BaseValidator, ICustomerValidator
    {
        public CustomerValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CustomerView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(CustomerView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(CustomerView view)
        {
            return ModelState.IsValid;
        }
    }
}
