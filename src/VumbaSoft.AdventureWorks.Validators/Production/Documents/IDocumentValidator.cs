using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IDocumentValidator : IValidator
    {
        Boolean CanCreate(DocumentView view);
        Boolean CanDelete(DocumentView view);
        Boolean CanEdit(DocumentView view);
    }
}
