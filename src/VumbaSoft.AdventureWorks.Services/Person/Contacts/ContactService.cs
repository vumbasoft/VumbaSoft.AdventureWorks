using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ContactService : BaseService, IContactService
    {
        public ContactService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Contact, TView>(id);
        }
        public IQueryable<ContactView> GetViews()
        {
            return UnitOfWork
                .Select<Contact>()
                .To<ContactView>()
                .OrderByDescending(contact => contact.Id);
        }

        public void Create(ContactView view)
        {
            Contact contact = UnitOfWork.To<Contact>(view);

            UnitOfWork.Insert(contact);
            UnitOfWork.Commit();
        }
        public void Edit(ContactView view)
        {
            Contact contact = UnitOfWork.To<Contact>(view);

            UnitOfWork.Update(contact);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Contact>(id);
            UnitOfWork.Commit();
        }
    }
}
