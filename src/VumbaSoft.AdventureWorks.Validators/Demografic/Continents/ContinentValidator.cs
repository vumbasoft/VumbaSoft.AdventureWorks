using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ContinentValidator : BaseValidator, IContinentValidator
    {
        public ContinentValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ContinentView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ContinentView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ContinentView view)
        {
            return ModelState.IsValid;
        }
    }
}
