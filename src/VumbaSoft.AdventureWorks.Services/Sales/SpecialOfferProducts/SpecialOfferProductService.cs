using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class SpecialOfferProductService : BaseService, ISpecialOfferProductService
    {
        public SpecialOfferProductService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<SpecialOfferProduct, TView>(id);
        }
        public IQueryable<SpecialOfferProductView> GetViews()
        {
            return UnitOfWork
                .Select<SpecialOfferProduct>()
                .To<SpecialOfferProductView>()
                .OrderByDescending(product => product.Id);
        }

        public void Create(SpecialOfferProductView view)
        {
            SpecialOfferProduct product = UnitOfWork.To<SpecialOfferProduct>(view);

            UnitOfWork.Insert(product);
            UnitOfWork.Commit();
        }
        public void Edit(SpecialOfferProductView view)
        {
            SpecialOfferProduct product = UnitOfWork.To<SpecialOfferProduct>(view);

            UnitOfWork.Update(product);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<SpecialOfferProduct>(id);
            UnitOfWork.Commit();
        }
    }
}
