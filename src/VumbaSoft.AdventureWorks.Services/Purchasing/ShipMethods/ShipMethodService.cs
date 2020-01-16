using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ShipMethodService : BaseService, IShipMethodService
    {
        public ShipMethodService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ShipMethod, TView>(id);
        }
        public IQueryable<ShipMethodView> GetViews()
        {
            return UnitOfWork
                .Select<ShipMethod>()
                .To<ShipMethodView>()
                .OrderByDescending(method => method.Id);
        }

        public void Create(ShipMethodView view)
        {
            ShipMethod method = UnitOfWork.To<ShipMethod>(view);

            UnitOfWork.Insert(method);
            UnitOfWork.Commit();
        }
        public void Edit(ShipMethodView view)
        {
            ShipMethod method = UnitOfWork.To<ShipMethod>(view);

            UnitOfWork.Update(method);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ShipMethod>(id);
            UnitOfWork.Commit();
        }
    }
}
