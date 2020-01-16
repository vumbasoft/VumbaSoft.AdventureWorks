using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ContactValidator : BaseValidator, IContactValidator
    {
        public ContactValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ContactView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ContactView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ContactView view)
        {
            return ModelState.IsValid;
        }
    }
}
