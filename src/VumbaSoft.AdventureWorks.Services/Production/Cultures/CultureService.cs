using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class CultureService : BaseService, ICultureService
    {
        public CultureService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Culture, TView>(id);
        }
        public IQueryable<CultureView> GetViews()
        {
            return UnitOfWork
                .Select<Culture>()
                .To<CultureView>()
                .OrderByDescending(culture => culture.Id);
        }

        public void Create(CultureView view)
        {
            Culture culture = UnitOfWork.To<Culture>(view);

            UnitOfWork.Insert(culture);
            UnitOfWork.Commit();
        }
        public void Edit(CultureView view)
        {
            Culture culture = UnitOfWork.To<Culture>(view);

            UnitOfWork.Update(culture);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Culture>(id);
            UnitOfWork.Commit();
        }
    }
}
