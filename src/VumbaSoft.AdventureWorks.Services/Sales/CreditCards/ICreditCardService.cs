using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ICreditCardService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<CreditCardView> GetViews();

        void Create(CreditCardView view);
        void Edit(CreditCardView view);
        void Delete(Int32 id);
    }
}
