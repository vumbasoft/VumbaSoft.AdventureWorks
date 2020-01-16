using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ISalesReasonValidator : IValidator
    {
        Boolean CanCreate(SalesReasonView view);
        Boolean CanDelete(SalesReasonView view);
        Boolean CanEdit(SalesReasonView view);
    }
}
