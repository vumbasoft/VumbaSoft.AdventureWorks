using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ISpecialOfferService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<SpecialOfferView> GetViews();

        void Create(SpecialOfferView view);
        void Edit(SpecialOfferView view);
        void Delete(Int32 id);
    }
}
