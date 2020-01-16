using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ProductDocumentValidator : BaseValidator, IProductDocumentValidator
    {
        public ProductDocumentValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductDocumentView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ProductDocumentView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ProductDocumentView view)
        {
            return ModelState.IsValid;
        }
    }
}
