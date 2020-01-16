using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class DepartmentValidator : BaseValidator, IDepartmentValidator
    {
        public DepartmentValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(DepartmentView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(DepartmentView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(DepartmentView view)
        {
            return ModelState.IsValid;
        }
    }
}
