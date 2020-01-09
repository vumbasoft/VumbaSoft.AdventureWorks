using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ProvinceValidator : BaseValidator, IProvinceValidator
    {
        public ProvinceValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProvinceView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ProvinceView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ProvinceView view)
        {
            return ModelState.IsValid;
        }
    }
}
