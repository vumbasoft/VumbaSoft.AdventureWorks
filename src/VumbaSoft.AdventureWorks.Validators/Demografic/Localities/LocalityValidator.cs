using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class LocalityValidator : BaseValidator, ILocalityValidator
    {
        public LocalityValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(LocalityView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(LocalityView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(LocalityView view)
        {
            return ModelState.IsValid;
        }
    }
}
