using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class SpecialOfferValidator : BaseValidator, ISpecialOfferValidator
    {
        public SpecialOfferValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(SpecialOfferView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(SpecialOfferView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(SpecialOfferView view)
        {
            return ModelState.IsValid;
        }
    }
}
