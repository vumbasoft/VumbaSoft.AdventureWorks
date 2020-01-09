using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class DistrictService : BaseService, IDistrictService
    {
        public DistrictService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<District, TView>(id);
        }
        public IQueryable<DistrictView> GetViews()
        {
            return UnitOfWork
                .Select<District>()
                .To<DistrictView>()
                .OrderByDescending(district => district.Id);
        }

        public void Create(DistrictView view)
        {
            District district = UnitOfWork.To<District>(view);

            UnitOfWork.Insert(district);
            UnitOfWork.Commit();
        }
        public void Edit(DistrictView view)
        {
            District district = UnitOfWork.To<District>(view);

            UnitOfWork.Update(district);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<District>(id);
            UnitOfWork.Commit();
        }
    }
}
