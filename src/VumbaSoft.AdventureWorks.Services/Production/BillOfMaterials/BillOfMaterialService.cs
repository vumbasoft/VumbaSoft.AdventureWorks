using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class BillOfMaterialService : BaseService, IBillOfMaterialService
    {
        public BillOfMaterialService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<BillOfMaterial, TView>(id);
        }
        public IQueryable<BillOfMaterialView> GetViews()
        {
            return UnitOfWork
                .Select<BillOfMaterial>()
                .To<BillOfMaterialView>()
                .OrderByDescending(material => material.Id);
        }

        public void Create(BillOfMaterialView view)
        {
            BillOfMaterial material = UnitOfWork.To<BillOfMaterial>(view);

            UnitOfWork.Insert(material);
            UnitOfWork.Commit();
        }
        public void Edit(BillOfMaterialView view)
        {
            BillOfMaterial material = UnitOfWork.To<BillOfMaterial>(view);

            UnitOfWork.Update(material);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<BillOfMaterial>(id);
            UnitOfWork.Commit();
        }
    }
}
