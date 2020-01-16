using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ITransactionHistoryArchiveValidator : IValidator
    {
        Boolean CanCreate(TransactionHistoryArchiveView view);
        Boolean CanDelete(TransactionHistoryArchiveView view);
        Boolean CanEdit(TransactionHistoryArchiveView view);
    }
}
