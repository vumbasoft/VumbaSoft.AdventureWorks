using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class IndividualValidator : BaseValidator, IIndividualValidator
    {
        public IndividualValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(IndividualView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(IndividualView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(IndividualView view)
        {
            return ModelState.IsValid;
        }
    }
}
