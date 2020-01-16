using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class SalesPersonQuotaHistoryValidator : BaseValidator, ISalesPersonQuotaHistoryValidator
    {
        public SalesPersonQuotaHistoryValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(SalesPersonQuotaHistoryView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(SalesPersonQuotaHistoryView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(SalesPersonQuotaHistoryView view)
        {
            return ModelState.IsValid;
        }
    }
}
