using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IContactService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ContactView> GetViews();

        void Create(ContactView view);
        void Edit(ContactView view);
        void Delete(Int32 id);
    }
}
