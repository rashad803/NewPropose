using System;
using System.Collections.Generic;
using NewPropose.DataAccess.IRepository;
using NewPropose.Models.ItemStates.ProplemStates;
using System.Linq;

namespace NewPropose.Models.Services.Imp
{
    public class WorkflowService : IWorkflowService
    {

        private readonly IProblemRepository _problemRepository;
        private readonly IProblemStateRepository _problemStateRepository;
        public WorkflowService(IProblemRepository problemRepository, IProblemStateRepository problemStateRepository)
        {
            _problemRepository = problemRepository;
            _problemStateRepository = problemStateRepository;
        }

        public IEnumerable<Problem> GetPeopleProblems()
        {
            var problems =
           _problemStateRepository.GetListByFilter(ps => ps.GetType() == typeof(TechnicalCommitteeState)).Select(
               ps => ps.Owner);
            return problems;
        }

        public IEnumerable<Problem> GetNewProblems()
        {
            var problems =
                _problemStateRepository.GetProblemsWithRegisterState();   
            return problems;
        }
    }
}