using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class StoreValidator : BaseValidator, IStoreValidator
    {
        public StoreValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(StoreView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(StoreView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(StoreView view)
        {
            return ModelState.IsValid;
        }
    }
}
