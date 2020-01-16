using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ShiftValidator : BaseValidator, IShiftValidator
    {
        public ShiftValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ShiftView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ShiftView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ShiftView view)
        {
            return ModelState.IsValid;
        }
    }
}
