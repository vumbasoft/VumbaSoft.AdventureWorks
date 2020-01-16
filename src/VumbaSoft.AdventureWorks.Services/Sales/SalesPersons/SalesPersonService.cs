using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class SalesPersonService : BaseService, ISalesPersonService
    {
        public SalesPersonService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<SalesPerson, TView>(id);
        }
        public IQueryable<SalesPersonView> GetViews()
        {
            return UnitOfWork
                .Select<SalesPerson>()
                .To<SalesPersonView>()
                .OrderByDescending(person => person.Id);
        }

        public void Create(SalesPersonView view)
        {
            SalesPerson person = UnitOfWork.To<SalesPerson>(view);

            UnitOfWork.Insert(person);
            UnitOfWork.Commit();
        }
        public void Edit(SalesPersonView view)
        {
            SalesPerson person = UnitOfWork.To<SalesPerson>(view);

            UnitOfWork.Update(person);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<SalesPerson>(id);
            UnitOfWork.Commit();
        }
    }
}
