using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IBillOfMaterialService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<BillOfMaterialView> GetViews();

        void Create(BillOfMaterialView view);
        void Edit(BillOfMaterialView view);
        void Delete(Int32 id);
    }
}
