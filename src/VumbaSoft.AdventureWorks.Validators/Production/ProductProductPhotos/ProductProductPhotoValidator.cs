using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ProductProductPhotoValidator : BaseValidator, IProductProductPhotoValidator
    {
        public ProductProductPhotoValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductProductPhotoView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ProductProductPhotoView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ProductProductPhotoView view)
        {
            return ModelState.IsValid;
        }
    }
}
