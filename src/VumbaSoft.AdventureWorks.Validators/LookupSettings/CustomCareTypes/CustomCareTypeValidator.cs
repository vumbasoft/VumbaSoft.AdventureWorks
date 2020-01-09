using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class CustomCareTypeValidator : BaseValidator, ICustomCareTypeValidator
    {
        public CustomCareTypeValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CustomCareTypeView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(CustomCareTypeView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(CustomCareTypeView view)
        {
            return ModelState.IsValid;
        }
    }
}
