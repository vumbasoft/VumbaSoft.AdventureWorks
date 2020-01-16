using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IShiftService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ShiftView> GetViews();

        void Create(ShiftView view);
        void Edit(ShiftView view);
        void Delete(Int32 id);
    }
}
