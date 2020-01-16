using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ProductModelIllustrationService : BaseService, IProductModelIllustrationService
    {
        public ProductModelIllustrationService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ProductModelIllustration, TView>(id);
        }
        public IQueryable<ProductModelIllustrationView> GetViews()
        {
            return UnitOfWork
                .Select<ProductModelIllustration>()
                .To<ProductModelIllustrationView>()
                .OrderByDescending(illustration => illustration.Id);
        }

        public void Create(ProductModelIllustrationView view)
        {
            ProductModelIllustration illustration = UnitOfWork.To<ProductModelIllustration>(view);

            UnitOfWork.Insert(illustration);
            UnitOfWork.Commit();
        }
        public void Edit(ProductModelIllustrationView view)
        {
            ProductModelIllustration illustration = UnitOfWork.To<ProductModelIllustration>(view);

            UnitOfWork.Update(illustration);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ProductModelIllustration>(id);
            UnitOfWork.Commit();
        }
    }
}
