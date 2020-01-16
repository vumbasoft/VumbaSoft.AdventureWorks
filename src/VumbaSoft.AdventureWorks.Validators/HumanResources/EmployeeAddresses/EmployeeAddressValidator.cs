using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class EmployeeAddressValidator : BaseValidator, IEmployeeAddressValidator
    {
        public EmployeeAddressValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(EmployeeAddressView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(EmployeeAddressView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(EmployeeAddressView view)
        {
            return ModelState.IsValid;
        }
    }
}
