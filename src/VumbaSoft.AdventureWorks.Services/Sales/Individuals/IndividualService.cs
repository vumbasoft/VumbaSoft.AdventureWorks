using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class IndividualService : BaseService, IIndividualService
    {
        public IndividualService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Individual, TView>(id);
        }
        public IQueryable<IndividualView> GetViews()
        {
            return UnitOfWork
                .Select<Individual>()
                .To<IndividualView>()
                .OrderByDescending(individual => individual.Id);
        }

        public void Create(IndividualView view)
        {
            Individual individual = UnitOfWork.To<Individual>(view);

            UnitOfWork.Insert(individual);
            UnitOfWork.Commit();
        }
        public void Edit(IndividualView view)
        {
            Individual individual = UnitOfWork.To<Individual>(view);

            UnitOfWork.Update(individual);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Individual>(id);
            UnitOfWork.Commit();
        }
    }
}
