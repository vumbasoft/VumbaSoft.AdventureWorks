using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class JobCandidateValidator : BaseValidator, IJobCandidateValidator
    {
        public JobCandidateValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(JobCandidateView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(JobCandidateView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(JobCandidateView view)
        {
            return ModelState.IsValid;
        }
    }
}
