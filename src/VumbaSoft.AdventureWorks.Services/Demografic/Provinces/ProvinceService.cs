using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ProvinceService : BaseService, IProvinceService
    {
        public ProvinceService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Province, TView>(id);
        }
        public IQueryable<ProvinceView> GetViews()
        {
            return UnitOfWork
                .Select<Province>()
                .To<ProvinceView>()
                .OrderByDescending(province => province.Id);
        }

        public void Create(ProvinceView view)
        {
            Province province = UnitOfWork.To<Province>(view);

            UnitOfWork.Insert(province);
            UnitOfWork.Commit();
        }
        public void Edit(ProvinceView view)
        {
            Province province = UnitOfWork.To<Province>(view);

            UnitOfWork.Update(province);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Province>(id);
            UnitOfWork.Commit();
        }
    }
}
