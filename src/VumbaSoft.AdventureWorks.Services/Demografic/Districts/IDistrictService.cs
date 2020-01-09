using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IDistrictService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<DistrictView> GetViews();

        void Create(DistrictView view);
        void Edit(DistrictView view);
        void Delete(Int32 id);
    }
}
