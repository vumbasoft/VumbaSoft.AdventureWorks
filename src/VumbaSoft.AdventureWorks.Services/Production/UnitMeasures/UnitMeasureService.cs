using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class UnitMeasureService : BaseService, IUnitMeasureService
    {
        public UnitMeasureService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<UnitMeasure, TView>(id);
        }
        public IQueryable<UnitMeasureView> GetViews()
        {
            return UnitOfWork
                .Select<UnitMeasure>()
                .To<UnitMeasureView>()
                .OrderByDescending(measure => measure.Id);
        }

        public void Create(UnitMeasureView view)
        {
            UnitMeasure measure = UnitOfWork.To<UnitMeasure>(view);

            UnitOfWork.Insert(measure);
            UnitOfWork.Commit();
        }
        public void Edit(UnitMeasureView view)
        {
            UnitMeasure measure = UnitOfWork.To<UnitMeasure>(view);

            UnitOfWork.Update(measure);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<UnitMeasure>(id);
            UnitOfWork.Commit();
        }
    }
}
