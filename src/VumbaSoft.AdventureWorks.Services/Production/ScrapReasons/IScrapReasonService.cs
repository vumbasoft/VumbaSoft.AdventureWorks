using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IScrapReasonService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ScrapReasonView> GetViews();

        void Create(ScrapReasonView view);
        void Edit(ScrapReasonView view);
        void Delete(Int32 id);
    }
}
