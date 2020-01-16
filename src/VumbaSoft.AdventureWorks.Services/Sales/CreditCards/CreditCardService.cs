using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class CreditCardService : BaseService, ICreditCardService
    {
        public CreditCardService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<CreditCard, TView>(id);
        }
        public IQueryable<CreditCardView> GetViews()
        {
            return UnitOfWork
                .Select<CreditCard>()
                .To<CreditCardView>()
                .OrderByDescending(card => card.Id);
        }

        public void Create(CreditCardView view)
        {
            CreditCard card = UnitOfWork.To<CreditCard>(view);

            UnitOfWork.Insert(card);
            UnitOfWork.Commit();
        }
        public void Edit(CreditCardView view)
        {
            CreditCard card = UnitOfWork.To<CreditCard>(view);

            UnitOfWork.Update(card);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<CreditCard>(id);
            UnitOfWork.Commit();
        }
    }
}
