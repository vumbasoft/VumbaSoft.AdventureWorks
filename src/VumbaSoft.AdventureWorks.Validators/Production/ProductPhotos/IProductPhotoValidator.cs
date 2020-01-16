using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IProductPhotoValidator : IValidator
    {
        Boolean CanCreate(ProductPhotoView view);
        Boolean CanDelete(ProductPhotoView view);
        Boolean CanEdit(ProductPhotoView view);
    }
}
