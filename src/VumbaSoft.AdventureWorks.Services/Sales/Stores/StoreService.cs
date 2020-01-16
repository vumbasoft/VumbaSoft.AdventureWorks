using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class StoreService : BaseService, IStoreService
    {
        public StoreService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Store, TView>(id);
        }
        public IQueryable<StoreView> GetViews()
        {
            return UnitOfWork
                .Select<Store>()
                .To<StoreView>()
                .OrderByDescending(store => store.Id);
        }

        public void Create(StoreView view)
        {
            Store store = UnitOfWork.To<Store>(view);

            UnitOfWork.Insert(store);
            UnitOfWork.Commit();
        }
        public void Edit(StoreView view)
        {
            Store store = UnitOfWork.To<Store>(view);

            UnitOfWork.Update(store);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Store>(id);
            UnitOfWork.Commit();
        }
    }
}
