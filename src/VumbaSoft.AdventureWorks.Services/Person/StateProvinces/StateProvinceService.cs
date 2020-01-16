using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class StateProvinceService : BaseService, IStateProvinceService
    {
        public StateProvinceService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<StateProvince, TView>(id);
        }
        public IQueryable<StateProvinceView> GetViews()
        {
            return UnitOfWork
                .Select<StateProvince>()
                .To<StateProvinceView>()
                .OrderByDescending(province => province.Id);
        }

        public void Create(StateProvinceView view)
        {
            StateProvince province = UnitOfWork.To<StateProvince>(view);

            UnitOfWork.Insert(province);
            UnitOfWork.Commit();
        }
        public void Edit(StateProvinceView view)
        {
            StateProvince province = UnitOfWork.To<StateProvince>(view);

            UnitOfWork.Update(province);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<StateProvince>(id);
            UnitOfWork.Commit();
        }
    }
}
