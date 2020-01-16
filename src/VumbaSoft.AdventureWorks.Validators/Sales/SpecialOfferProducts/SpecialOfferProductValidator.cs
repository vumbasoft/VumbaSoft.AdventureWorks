using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class SpecialOfferProductValidator : BaseValidator, ISpecialOfferProductValidator
    {
        public SpecialOfferProductValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(SpecialOfferProductView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(SpecialOfferProductView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(SpecialOfferProductView view)
        {
            return ModelState.IsValid;
        }
    }
}
