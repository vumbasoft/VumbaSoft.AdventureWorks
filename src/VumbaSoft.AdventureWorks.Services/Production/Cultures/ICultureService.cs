using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ICultureService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<CultureView> GetViews();

        void Create(CultureView view);
        void Edit(CultureView view);
        void Delete(Int32 id);
    }
}
