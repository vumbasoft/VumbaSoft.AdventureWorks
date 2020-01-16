using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class StoreContactService : BaseService, IStoreContactService
    {
        public StoreContactService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<StoreContact, TView>(id);
        }
        public IQueryable<StoreContactView> GetViews()
        {
            return UnitOfWork
                .Select<StoreContact>()
                .To<StoreContactView>()
                .OrderByDescending(contact => contact.Id);
        }

        public void Create(StoreContactView view)
        {
            StoreContact contact = UnitOfWork.To<StoreContact>(view);

            UnitOfWork.Insert(contact);
            UnitOfWork.Commit();
        }
        public void Edit(StoreContactView view)
        {
            StoreContact contact = UnitOfWork.To<StoreContact>(view);

            UnitOfWork.Update(contact);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<StoreContact>(id);
            UnitOfWork.Commit();
        }
    }
}
