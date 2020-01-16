using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IStateProvinceService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<StateProvinceView> GetViews();

        void Create(StateProvinceView view);
        void Edit(StateProvinceView view);
        void Delete(Int32 id);
    }
}
