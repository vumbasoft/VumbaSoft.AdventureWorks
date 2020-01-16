using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ISpecialOfferProductValidator : IValidator
    {
        Boolean CanCreate(SpecialOfferProductView view);
        Boolean CanDelete(SpecialOfferProductView view);
        Boolean CanEdit(SpecialOfferProductView view);
    }
}
