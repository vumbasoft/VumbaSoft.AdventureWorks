using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ContactCreditCardService : BaseService, IContactCreditCardService
    {
        public ContactCreditCardService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ContactCreditCard, TView>(id);
        }
        public IQueryable<ContactCreditCardView> GetViews()
        {
            return UnitOfWork
                .Select<ContactCreditCard>()
                .To<ContactCreditCardView>()
                .OrderByDescending(card => card.Id);
        }

        public void Create(ContactCreditCardView view)
        {
            ContactCreditCard card = UnitOfWork.To<ContactCreditCard>(view);

            UnitOfWork.Insert(card);
            UnitOfWork.Commit();
        }
        public void Edit(ContactCreditCardView view)
        {
            ContactCreditCard card = UnitOfWork.To<ContactCreditCard>(view);

            UnitOfWork.Update(card);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ContactCreditCard>(id);
            UnitOfWork.Commit();
        }
    }
}
