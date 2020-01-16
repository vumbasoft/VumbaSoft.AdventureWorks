using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ContactTypeValidator : BaseValidator, IContactTypeValidator
    {
        public ContactTypeValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ContactTypeView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ContactTypeView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ContactTypeView view)
        {
            return ModelState.IsValid;
        }
    }
}
