using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class StoreContactValidator : BaseValidator, IStoreContactValidator
    {
        public StoreContactValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(StoreContactView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(StoreContactView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(StoreContactView view)
        {
            return ModelState.IsValid;
        }
    }
}
