using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class DocumentService : BaseService, IDocumentService
    {
        public DocumentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Document, TView>(id);
        }
        public IQueryable<DocumentView> GetViews()
        {
            return UnitOfWork
                .Select<Document>()
                .To<DocumentView>()
                .OrderByDescending(document => document.Id);
        }

        public void Create(DocumentView view)
        {
            Document document = UnitOfWork.To<Document>(view);

            UnitOfWork.Insert(document);
            UnitOfWork.Commit();
        }
        public void Edit(DocumentView view)
        {
            Document document = UnitOfWork.To<Document>(view);

            UnitOfWork.Update(document);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Document>(id);
            UnitOfWork.Commit();
        }
    }
}
