using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class SalesReasonValidator : BaseValidator, ISalesReasonValidator
    {
        public SalesReasonValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(SalesReasonView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(SalesReasonView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(SalesReasonView view)
        {
            return ModelState.IsValid;
        }
    }
}
