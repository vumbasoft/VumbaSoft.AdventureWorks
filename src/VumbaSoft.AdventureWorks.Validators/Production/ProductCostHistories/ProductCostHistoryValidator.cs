using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ProductCostHistoryValidator : BaseValidator, IProductCostHistoryValidator
    {
        public ProductCostHistoryValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductCostHistoryView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ProductCostHistoryView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ProductCostHistoryView view)
        {
            return ModelState.IsValid;
        }
    }
}
