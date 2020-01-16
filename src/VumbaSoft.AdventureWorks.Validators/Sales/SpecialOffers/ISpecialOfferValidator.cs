using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ISpecialOfferValidator : IValidator
    {
        Boolean CanCreate(SpecialOfferView view);
        Boolean CanDelete(SpecialOfferView view);
        Boolean CanEdit(SpecialOfferView view);
    }
}
