using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IJobCandidateValidator : IValidator
    {
        Boolean CanCreate(JobCandidateView view);
        Boolean CanDelete(JobCandidateView view);
        Boolean CanEdit(JobCandidateView view);
    }
}
