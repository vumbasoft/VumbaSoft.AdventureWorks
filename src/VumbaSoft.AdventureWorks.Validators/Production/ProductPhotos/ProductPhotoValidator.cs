using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ProductPhotoValidator : BaseValidator, IProductPhotoValidator
    {
        public ProductPhotoValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductPhotoView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ProductPhotoView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ProductPhotoView view)
        {
            return ModelState.IsValid;
        }
    }
}
