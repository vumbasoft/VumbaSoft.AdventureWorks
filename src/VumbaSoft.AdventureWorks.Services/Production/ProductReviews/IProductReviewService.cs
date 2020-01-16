using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IProductReviewService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ProductReviewView> GetViews();

        void Create(ProductReviewView view);
        void Edit(ProductReviewView view);
        void Delete(Int32 id);
    }
}
