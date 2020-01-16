using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ProductReviewService : BaseService, IProductReviewService
    {
        public ProductReviewService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ProductReview, TView>(id);
        }
        public IQueryable<ProductReviewView> GetViews()
        {
            return UnitOfWork
                .Select<ProductReview>()
                .To<ProductReviewView>()
                .OrderByDescending(review => review.Id);
        }

        public void Create(ProductReviewView view)
        {
            ProductReview review = UnitOfWork.To<ProductReview>(view);

            UnitOfWork.Insert(review);
            UnitOfWork.Commit();
        }
        public void Edit(ProductReviewView view)
        {
            ProductReview review = UnitOfWork.To<ProductReview>(view);

            UnitOfWork.Update(review);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ProductReview>(id);
            UnitOfWork.Commit();
        }
    }
}
