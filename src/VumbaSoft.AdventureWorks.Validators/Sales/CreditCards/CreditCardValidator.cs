using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class CreditCardValidator : BaseValidator, ICreditCardValidator
    {
        public CreditCardValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CreditCardView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(CreditCardView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(CreditCardView view)
        {
            return ModelState.IsValid;
        }
    }
}
