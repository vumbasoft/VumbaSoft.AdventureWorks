using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class TransactionHistoryValidator : BaseValidator, ITransactionHistoryValidator
    {
        public TransactionHistoryValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(TransactionHistoryView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(TransactionHistoryView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(TransactionHistoryView view)
        {
            return ModelState.IsValid;
        }
    }
}
