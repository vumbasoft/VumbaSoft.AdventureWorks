using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class BillOfMaterialValidator : BaseValidator, IBillOfMaterialValidator
    {
        public BillOfMaterialValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(BillOfMaterialView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(BillOfMaterialView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(BillOfMaterialView view)
        {
            return ModelState.IsValid;
        }
    }
}
