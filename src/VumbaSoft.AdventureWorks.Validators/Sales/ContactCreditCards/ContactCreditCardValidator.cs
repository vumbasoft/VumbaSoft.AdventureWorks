using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ContactCreditCardValidator : BaseValidator, IContactCreditCardValidator
    {
        public ContactCreditCardValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ContactCreditCardView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ContactCreditCardView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ContactCreditCardView view)
        {
            return ModelState.IsValid;
        }
    }
}
