using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ProductInventoryValidator : BaseValidator, IProductInventoryValidator
    {
        public ProductInventoryValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductInventoryView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ProductInventoryView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ProductInventoryView view)
        {
            return ModelState.IsValid;
        }
    }
}
