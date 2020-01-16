using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class EmployeedepartmenthistoryValidator : BaseValidator, IEmployeedepartmenthistoryValidator
    {
        public EmployeedepartmenthistoryValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(EmployeeDepartmentHistoryView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(EmployeeDepartmentHistoryView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(EmployeeDepartmentHistoryView view)
        {
            return ModelState.IsValid;
        }
    }
}
