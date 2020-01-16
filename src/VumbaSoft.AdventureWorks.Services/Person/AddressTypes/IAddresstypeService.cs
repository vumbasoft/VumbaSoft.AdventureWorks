using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IAddresstypeService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<AddresstypeView> GetViews();

        void Create(AddresstypeView view);
        void Edit(AddresstypeView view);
        void Delete(Int32 id);
    }
}
