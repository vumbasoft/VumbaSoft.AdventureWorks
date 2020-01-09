using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class CustomCareTypeService : BaseService, ICustomCareTypeService
    {
        public CustomCareTypeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<CustomCareType, TView>(id);
        }
        public IQueryable<CustomCareTypeView> GetViews()
        {
            return UnitOfWork
                .Select<CustomCareType>()
                .To<CustomCareTypeView>()
                .OrderByDescending(type => type.Id);
        }

        public void Create(CustomCareTypeView view)
        {
            CustomCareType type = UnitOfWork.To<CustomCareType>(view);

            UnitOfWork.Insert(type);
            UnitOfWork.Commit();
        }
        public void Edit(CustomCareTypeView view)
        {
            CustomCareType type = UnitOfWork.To<CustomCareType>(view);

            UnitOfWork.Update(type);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<CustomCareType>(id);
            UnitOfWork.Commit();
        }
    }
}
