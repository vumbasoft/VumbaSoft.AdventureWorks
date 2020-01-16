using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class SalesPersonValidator : BaseValidator, ISalesPersonValidator
    {
        public SalesPersonValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(SalesPersonView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(SalesPersonView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(SalesPersonView view)
        {
            return ModelState.IsValid;
        }
    }
}
