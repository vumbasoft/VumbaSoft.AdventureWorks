using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IJobCandidateService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<JobCandidateView> GetViews();

        void Create(JobCandidateView view);
        void Edit(JobCandidateView view);
        void Delete(Int32 id);
    }
}
