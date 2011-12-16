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
            return _problemRepository.GetProblemsWithTechnicalCommitteeState();
        }

        public IEnumerable<Problem> GetNewProblems()
        {
            return _problemRepository.GetProblemsWithRegisterState();                
        }

        public IEnumerable<Problem> GetProblemsForSuperCommitee()
        {
            return _problemRepository.GetProblemsForSuperCommitee();
        }
    }
}