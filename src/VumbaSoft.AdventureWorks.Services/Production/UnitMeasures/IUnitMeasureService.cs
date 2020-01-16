using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IUnitMeasureService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<UnitMeasureView> GetViews();

        void Create(UnitMeasureView view);
        void Edit(UnitMeasureView view);
        void Delete(Int32 id);
    }
}
