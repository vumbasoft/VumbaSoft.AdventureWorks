using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class PurchaseOrderDetailValidator : BaseValidator, IPurchaseOrderDetailValidator
    {
        public PurchaseOrderDetailValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(PurchaseOrderDetailView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(PurchaseOrderDetailView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(PurchaseOrderDetailView view)
        {
            return ModelState.IsValid;
        }
    }
}
