using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class PurchaseOrderHeaderValidator : BaseValidator, IPurchaseOrderHeaderValidator
    {
        public PurchaseOrderHeaderValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(PurchaseOrderHeaderView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(PurchaseOrderHeaderView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(PurchaseOrderHeaderView view)
        {
            return ModelState.IsValid;
        }
    }
}
