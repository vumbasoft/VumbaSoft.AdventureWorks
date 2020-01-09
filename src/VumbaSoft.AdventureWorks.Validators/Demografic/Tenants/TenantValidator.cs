using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class TenantValidator : BaseValidator, ITenantValidator
    {
        public TenantValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(TenantView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(TenantView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(TenantView view)
        {
            return ModelState.IsValid;
        }
    }
}
