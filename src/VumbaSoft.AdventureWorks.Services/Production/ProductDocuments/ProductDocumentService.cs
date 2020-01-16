using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ProductDocumentService : BaseService, IProductDocumentService
    {
        public ProductDocumentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ProductDocument, TView>(id);
        }
        public IQueryable<ProductDocumentView> GetViews()
        {
            return UnitOfWork
                .Select<ProductDocument>()
                .To<ProductDocumentView>()
                .OrderByDescending(document => document.Id);
        }

        public void Create(ProductDocumentView view)
        {
            ProductDocument document = UnitOfWork.To<ProductDocument>(view);

            UnitOfWork.Insert(document);
            UnitOfWork.Commit();
        }
        public void Edit(ProductDocumentView view)
        {
            ProductDocument document = UnitOfWork.To<ProductDocument>(view);

            UnitOfWork.Update(document);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ProductDocument>(id);
            UnitOfWork.Commit();
        }
    }
}
