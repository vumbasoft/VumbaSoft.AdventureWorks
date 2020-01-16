using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ILocationService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<LocationView> GetViews();

        void Create(LocationView view);
        void Edit(LocationView view);
        void Delete(Int32 id);
    }
}
