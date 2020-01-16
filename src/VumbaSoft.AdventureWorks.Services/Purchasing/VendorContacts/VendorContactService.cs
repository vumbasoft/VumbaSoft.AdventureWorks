using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class VendorContactService : BaseService, IVendorContactService
    {
        public VendorContactService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<VendorContact, TView>(id);
        }
        public IQueryable<VendorContactView> GetViews()
        {
            return UnitOfWork
                .Select<VendorContact>()
                .To<VendorContactView>()
                .OrderByDescending(contact => contact.Id);
        }

        public void Create(VendorContactView view)
        {
            VendorContact contact = UnitOfWork.To<VendorContact>(view);

            UnitOfWork.Insert(contact);
            UnitOfWork.Commit();
        }
        public void Edit(VendorContactView view)
        {
            VendorContact contact = UnitOfWork.To<VendorContact>(view);

            UnitOfWork.Update(contact);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<VendorContact>(id);
            UnitOfWork.Commit();
        }
    }
}
