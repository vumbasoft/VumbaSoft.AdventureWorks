using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ITransactionHistoryArchiveService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<TransactionHistoryArchiveView> GetViews();

        void Create(TransactionHistoryArchiveView view);
        void Edit(TransactionHistoryArchiveView view);
        void Delete(Int32 id);
    }
}
