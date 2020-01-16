using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ScrapReasonValidator : BaseValidator, IScrapReasonValidator
    {
        public ScrapReasonValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ScrapReasonView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ScrapReasonView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ScrapReasonView view)
        {
            return ModelState.IsValid;
        }
    }
}
