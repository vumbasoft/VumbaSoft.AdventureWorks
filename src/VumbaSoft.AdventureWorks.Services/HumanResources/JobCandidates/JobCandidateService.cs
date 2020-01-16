using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class JobCandidateService : BaseService, IJobCandidateService
    {
        public JobCandidateService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<JobCandidate, TView>(id);
        }
        public IQueryable<JobCandidateView> GetViews()
        {
            return UnitOfWork
                .Select<JobCandidate>()
                .To<JobCandidateView>()
                .OrderByDescending(candidate => candidate.Id);
        }

        public void Create(JobCandidateView view)
        {
            JobCandidate candidate = UnitOfWork.To<JobCandidate>(view);

            UnitOfWork.Insert(candidate);
            UnitOfWork.Commit();
        }
        public void Edit(JobCandidateView view)
        {
            JobCandidate candidate = UnitOfWork.To<JobCandidate>(view);

            UnitOfWork.Update(candidate);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<JobCandidate>(id);
            UnitOfWork.Commit();
        }
    }
}
