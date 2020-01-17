using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IIllustrationService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<IllustrationView> GetViews();

        void Create(IllustrationView view);
        void Edit(IllustrationView view);
        void Delete(Int32 id);
    }
}