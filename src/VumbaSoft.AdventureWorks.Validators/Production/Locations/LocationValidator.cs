using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class LocationValidator : BaseValidator, ILocationValidator
    {
        public LocationValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(LocationView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(LocationView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(LocationView view)
        {
            return ModelState.IsValid;
        }
    }
}
