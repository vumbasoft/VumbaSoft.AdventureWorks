using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ISpecialOfferProductService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<SpecialOfferProductView> GetViews();

        void Create(SpecialOfferProductView view);
        void Edit(SpecialOfferProductView view);
        void Delete(Int32 id);
    }
}
