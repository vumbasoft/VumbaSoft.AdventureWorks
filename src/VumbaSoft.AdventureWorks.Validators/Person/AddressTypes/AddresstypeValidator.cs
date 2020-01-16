using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class AddresstypeValidator : BaseValidator, IAddresstypeValidator
    {
        public AddresstypeValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(AddresstypeView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(AddresstypeView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(AddresstypeView view)
        {
            return ModelState.IsValid;
        }
    }
}
