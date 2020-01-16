using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class TransactionHistoryArchiveService : BaseService, ITransactionHistoryArchiveService
    {
        public TransactionHistoryArchiveService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<TransactionHistoryArchive, TView>(id);
        }
        public IQueryable<TransactionHistoryArchiveView> GetViews()
        {
            return UnitOfWork
                .Select<TransactionHistoryArchive>()
                .To<TransactionHistoryArchiveView>()
                .OrderByDescending(archive => archive.Id);
        }

        public void Create(TransactionHistoryArchiveView view)
        {
            TransactionHistoryArchive archive = UnitOfWork.To<TransactionHistoryArchive>(view);

            UnitOfWork.Insert(archive);
            UnitOfWork.Commit();
        }
        public void Edit(TransactionHistoryArchiveView view)
        {
            TransactionHistoryArchive archive = UnitOfWork.To<TransactionHistoryArchive>(view);

            UnitOfWork.Update(archive);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<TransactionHistoryArchive>(id);
            UnitOfWork.Commit();
        }
    }
}
