using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class AddresstypeService : BaseService, IAddresstypeService
    {
        public AddresstypeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Addresstype, TView>(id);
        }
        public IQueryable<AddresstypeView> GetViews()
        {
            return UnitOfWork
                .Select<Addresstype>()
                .To<AddresstypeView>()
                .OrderByDescending(addresstype => addresstype.Id);
        }

        public void Create(AddresstypeView view)
        {
            Addresstype addresstype = UnitOfWork.To<Addresstype>(view);

            UnitOfWork.Insert(addresstype);
            UnitOfWork.Commit();
        }
        public void Edit(AddresstypeView view)
        {
            Addresstype addresstype = UnitOfWork.To<Addresstype>(view);

            UnitOfWork.Update(addresstype);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Addresstype>(id);
            UnitOfWork.Commit();
        }
    }
}
