using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ContactTypeService : BaseService, IContactTypeService
    {
        public ContactTypeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ContactType, TView>(id);
        }
        public IQueryable<ContactTypeView> GetViews()
        {
            return UnitOfWork
                .Select<ContactType>()
                .To<ContactTypeView>()
                .OrderByDescending(type => type.Id);
        }

        public void Create(ContactTypeView view)
        {
            ContactType type = UnitOfWork.To<ContactType>(view);

            UnitOfWork.Insert(type);
            UnitOfWork.Commit();
        }
        public void Edit(ContactTypeView view)
        {
            ContactType type = UnitOfWork.To<ContactType>(view);

            UnitOfWork.Update(type);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ContactType>(id);
            UnitOfWork.Commit();
        }
    }
}
