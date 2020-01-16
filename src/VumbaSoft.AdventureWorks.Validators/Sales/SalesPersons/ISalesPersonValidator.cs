using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ISalesPersonValidator : IValidator
    {
        Boolean CanCreate(SalesPersonView view);
        Boolean CanDelete(SalesPersonView view);
        Boolean CanEdit(SalesPersonView view);
    }
}
