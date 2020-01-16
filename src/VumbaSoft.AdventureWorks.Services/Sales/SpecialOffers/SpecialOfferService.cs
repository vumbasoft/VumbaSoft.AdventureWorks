using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class SpecialOfferService : BaseService, ISpecialOfferService
    {
        public SpecialOfferService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<SpecialOffer, TView>(id);
        }
        public IQueryable<SpecialOfferView> GetViews()
        {
            return UnitOfWork
                .Select<SpecialOffer>()
                .To<SpecialOfferView>()
                .OrderByDescending(offer => offer.Id);
        }

        public void Create(SpecialOfferView view)
        {
            SpecialOffer offer = UnitOfWork.To<SpecialOffer>(view);

            UnitOfWork.Insert(offer);
            UnitOfWork.Commit();
        }
        public void Edit(SpecialOfferView view)
        {
            SpecialOffer offer = UnitOfWork.To<SpecialOffer>(view);

            UnitOfWork.Update(offer);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<SpecialOffer>(id);
            UnitOfWork.Commit();
        }
    }
}
