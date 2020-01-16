using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ITransactionHistoryValidator : IValidator
    {
        Boolean CanCreate(TransactionHistoryView view);
        Boolean CanDelete(TransactionHistoryView view);
        Boolean CanEdit(TransactionHistoryView view);
    }
}
