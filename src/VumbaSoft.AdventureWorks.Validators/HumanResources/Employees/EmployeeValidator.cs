using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class EmployeeValidator : BaseValidator, IEmployeeValidator
    {
        public EmployeeValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(EmployeeView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(EmployeeView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(EmployeeView view)
        {
            return ModelState.IsValid;
        }
    }
}
