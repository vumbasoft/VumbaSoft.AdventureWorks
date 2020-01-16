using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IContactCreditCardService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ContactCreditCardView> GetViews();

        void Create(ContactCreditCardView view);
        void Edit(ContactCreditCardView view);
        void Delete(Int32 id);
    }
}
