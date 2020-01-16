using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class IllustrationValidator : BaseValidator, IIllustrationValidator
    {
        public IllustrationValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(IllustrationView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(IllustrationView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(IllustrationView view)
        {
            return ModelState.IsValid;
        }
    }
}
