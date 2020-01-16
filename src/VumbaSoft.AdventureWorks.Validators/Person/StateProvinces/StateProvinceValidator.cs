using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class StateProvinceValidator : BaseValidator, IStateProvinceValidator
    {
        public StateProvinceValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(StateProvinceView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(StateProvinceView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(StateProvinceView view)
        {
            return ModelState.IsValid;
        }
    }
}
