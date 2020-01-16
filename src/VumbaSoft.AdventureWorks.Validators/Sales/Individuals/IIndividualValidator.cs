using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IIndividualValidator : IValidator
    {
        Boolean CanCreate(IndividualView view);
        Boolean CanDelete(IndividualView view);
        Boolean CanEdit(IndividualView view);
    }
}
