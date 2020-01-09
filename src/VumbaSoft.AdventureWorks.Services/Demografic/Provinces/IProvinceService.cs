using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IProvinceService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ProvinceView> GetViews();

        void Create(ProvinceView view);
        void Edit(ProvinceView view);
        void Delete(Int32 id);
    }
}
