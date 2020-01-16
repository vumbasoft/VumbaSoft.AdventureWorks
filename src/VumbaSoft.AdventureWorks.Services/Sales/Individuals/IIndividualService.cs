using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IIndividualService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<IndividualView> GetViews();

        void Create(IndividualView view);
        void Edit(IndividualView view);
        void Delete(Int32 id);
    }
}
