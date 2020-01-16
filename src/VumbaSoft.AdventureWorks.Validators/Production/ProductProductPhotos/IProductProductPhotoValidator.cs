using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IProductProductPhotoValidator : IValidator
    {
        Boolean CanCreate(ProductProductPhotoView view);
        Boolean CanDelete(ProductProductPhotoView view);
        Boolean CanEdit(ProductProductPhotoView view);
    }
}
