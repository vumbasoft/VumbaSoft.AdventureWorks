using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ShiftService : BaseService, IShiftService
    {
        public ShiftService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Shift, TView>(id);
        }
        public IQueryable<ShiftView> GetViews()
        {
            return UnitOfWork
                .Select<Shift>()
                .To<ShiftView>()
                .OrderByDescending(shift => shift.Id);
        }

        public void Create(ShiftView view)
        {
            Shift shift = UnitOfWork.To<Shift>(view);

            UnitOfWork.Insert(shift);
            UnitOfWork.Commit();
        }
        public void Edit(ShiftView view)
        {
            Shift shift = UnitOfWork.To<Shift>(view);

            UnitOfWork.Update(shift);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Shift>(id);
            UnitOfWork.Commit();
        }
    }
}
