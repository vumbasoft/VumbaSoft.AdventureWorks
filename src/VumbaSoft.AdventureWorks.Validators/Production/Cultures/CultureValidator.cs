using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class CultureValidator : BaseValidator, ICultureValidator
    {
        public CultureValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CultureView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(CultureView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(CultureView view)
        {
            return ModelState.IsValid;
        }
    }
}
