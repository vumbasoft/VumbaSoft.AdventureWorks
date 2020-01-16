using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ProductModelService : BaseService, IProductModelService
    {
        public ProductModelService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ProductModel, TView>(id);
        }
        public IQueryable<ProductModelView> GetViews()
        {
            return UnitOfWork
                .Select<ProductModel>()
                .To<ProductModelView>()
                .OrderByDescending(model => model.Id);
        }

        public void Create(ProductModelView view)
        {
            ProductModel model = UnitOfWork.To<ProductModel>(view);

            UnitOfWork.Insert(model);
            UnitOfWork.Commit();
        }
        public void Edit(ProductModelView view)
        {
            ProductModel model = UnitOfWork.To<ProductModel>(view);

            UnitOfWork.Update(model);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ProductModel>(id);
            UnitOfWork.Commit();
        }
    }
}
