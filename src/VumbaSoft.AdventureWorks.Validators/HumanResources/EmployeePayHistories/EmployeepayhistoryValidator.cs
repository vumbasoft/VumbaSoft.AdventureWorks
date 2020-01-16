using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class EmployeepayhistoryValidator : BaseValidator, IEmployeepayhistoryValidator
    {
        public EmployeepayhistoryValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(EmployeePayHistoryView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(EmployeePayHistoryView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(EmployeePayHistoryView view)
        {
            return ModelState.IsValid;
        }
    }
}
