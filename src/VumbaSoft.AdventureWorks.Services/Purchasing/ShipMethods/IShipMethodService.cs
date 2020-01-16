using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IShipMethodService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ShipMethodView> GetViews();

        void Create(ShipMethodView view);
        void Edit(ShipMethodView view);
        void Delete(Int32 id);
    }
}
