using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IDocumentService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<DocumentView> GetViews();

        void Create(DocumentView view);
        void Edit(DocumentView view);
        void Delete(Int32 id);
    }
}
