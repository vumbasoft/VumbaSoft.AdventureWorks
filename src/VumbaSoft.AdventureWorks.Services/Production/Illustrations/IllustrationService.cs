using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class IllustrationService : BaseService, IIllustrationService
    {
        public IllustrationService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Illustration, TView>(id);
        }
        public IQueryable<IllustrationView> GetViews()
        {
            return UnitOfWork
                .Select<Illustration>()
                .To<IllustrationView>()
                .OrderByDescending(illustration => illustration.Id);
        }

        public void Create(IllustrationView view)
        {
            Illustration illustration = UnitOfWork.To<Illustration>(view);

            UnitOfWork.Insert(illustration);
            UnitOfWork.Commit();
        }
        public void Edit(IllustrationView view)
        {
            Illustration illustration = UnitOfWork.To<Illustration>(view);

            UnitOfWork.Update(illustration);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Illustration>(id);
            UnitOfWork.Commit();
        }
    }
}
