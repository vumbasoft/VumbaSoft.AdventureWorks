using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class TransactionHistoryService : BaseService, ITransactionHistoryService
    {
        public TransactionHistoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<TransactionHistory, TView>(id);
        }
        public IQueryable<TransactionHistoryView> GetViews()
        {
            return UnitOfWork
                .Select<TransactionHistory>()
                .To<TransactionHistoryView>()
                .OrderByDescending(history => history.Id);
        }

        public void Create(TransactionHistoryView view)
        {
            TransactionHistory history = UnitOfWork.To<TransactionHistory>(view);

            UnitOfWork.Insert(history);
            UnitOfWork.Commit();
        }
        public void Edit(TransactionHistoryView view)
        {
            TransactionHistory history = UnitOfWork.To<TransactionHistory>(view);

            UnitOfWork.Update(history);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<TransactionHistory>(id);
            UnitOfWork.Commit();
        }
    }
}
