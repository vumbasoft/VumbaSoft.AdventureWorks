using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IProductDocumentValidator : IValidator
    {
        Boolean CanCreate(ProductDocumentView view);
        Boolean CanDelete(ProductDocumentView view);
        Boolean CanEdit(ProductDocumentView view);
    }
}
