using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ICustomCareTypeService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<CustomCareTypeView> GetViews();

        void Create(CustomCareTypeView view);
        void Edit(CustomCareTypeView view);
        void Delete(Int32 id);
    }
}
