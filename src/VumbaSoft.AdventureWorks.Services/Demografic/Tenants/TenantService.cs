using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class TenantService : BaseService, ITenantService
    {
        public TenantService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Tenant, TView>(id);
        }
        public IQueryable<TenantView> GetViews()
        {
            return UnitOfWork
                .Select<Tenant>()
                .To<TenantView>()
                .OrderByDescending(tenant => tenant.Id);
        }

        public void Create(TenantView view)
        {
            Tenant tenant = UnitOfWork.To<Tenant>(view);

            UnitOfWork.Insert(tenant);
            UnitOfWork.Commit();
        }
        public void Edit(TenantView view)
        {
            Tenant tenant = UnitOfWork.To<Tenant>(view);

            UnitOfWork.Update(tenant);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Tenant>(id);
            UnitOfWork.Commit();
        }
    }
}
