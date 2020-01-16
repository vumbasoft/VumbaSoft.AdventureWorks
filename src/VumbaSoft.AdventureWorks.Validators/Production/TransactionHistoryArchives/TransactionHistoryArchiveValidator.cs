using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class TransactionHistoryArchiveValidator : BaseValidator, ITransactionHistoryArchiveValidator
    {
        public TransactionHistoryArchiveValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(TransactionHistoryArchiveView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(TransactionHistoryArchiveView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(TransactionHistoryArchiveView view)
        {
            return ModelState.IsValid;
        }
    }
}
