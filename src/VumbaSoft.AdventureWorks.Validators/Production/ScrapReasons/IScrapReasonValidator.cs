using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IScrapReasonValidator : IValidator
    {
        Boolean CanCreate(ScrapReasonView view);
        Boolean CanDelete(ScrapReasonView view);
        Boolean CanEdit(ScrapReasonView view);
    }
}
