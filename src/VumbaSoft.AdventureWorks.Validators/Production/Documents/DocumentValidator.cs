using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class DocumentValidator : BaseValidator, IDocumentValidator
    {
        public DocumentValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(DocumentView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(DocumentView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(DocumentView view)
        {
            return ModelState.IsValid;
        }
    }
}
