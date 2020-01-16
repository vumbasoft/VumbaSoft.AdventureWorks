using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IContactTypeService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ContactTypeView> GetViews();

        void Create(ContactTypeView view);
        void Edit(ContactTypeView view);
        void Delete(Int32 id);
    }
}
