using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IProductDocumentService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ProductDocumentView> GetViews();

        void Create(ProductDocumentView view);
        void Edit(ProductDocumentView view);
        void Delete(Int32 id);
    }
}
