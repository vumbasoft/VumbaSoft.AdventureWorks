using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class UnitMeasureValidator : BaseValidator, IUnitMeasureValidator
    {
        public UnitMeasureValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(UnitMeasureView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(UnitMeasureView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(UnitMeasureView view)
        {
            return ModelState.IsValid;
        }
    }
}
