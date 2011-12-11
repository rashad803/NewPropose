using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewPropose.Models.ItemStates;
using NewPropose.Models.Services;
using Xunit;
using Moq;
using NewPropose.DataAccess.IRepository;
using NewPropose.Models.ItemStates.ProplemStates;
using NewPropose.Models;
using NewPropose.DataAccess.Repository;
using NewPropose.DataAccess;

namespace NewProposeTest
{
    public static class ObjectMother
    {
        public static IProblemRepository GetProblemRepository()
        {
            var m = new Mock<IDatabaseFactory>();
            var repo = new ProblemRepository(m.Object);                     
            return repo;
        }

        public static IProposalRepository GetProposalRepository()
        {
            var m = new Mock<IDatabaseFactory>();
            var repo = new ProposalRepository(m.Object);
            return repo;
        }

        public static IWorkflowService GetWorkflowService()
        {
            var service = new Mock<IWorkflowService>();
            service.Setup(s => s.GetPeopleProblems()).Returns(new List<Problem>(){BuildProblem()});
            service.Setup(s => s.GetNewProblems()).Returns(new List<Problem>() { BuildProblem() });  
            return service.Object;
        }

        public static IUnitRepository GetUnitRepository()
        {
            var m = new Mock<IUnitRepository>();
            var unit = BuildUnit();
            unit.Type = "TechnicalCommite";
            m.Setup(repo => repo.GetAllTechnicalCommites()).Returns(new List<Unit>() { unit });
            return m.Object;
        }

        public static Unit BuildUnit()
        {
            var unit = new Unit() { Name = "Mock Unit" };            
            return unit;
        }

        public static ProblemRegisterState BuildRegisterState()
        {
            var registerState = new ProblemRegisterState() { IsCurrent = true };
            return registerState;
        }

        public static Problem BuildProblem()
        {
            var problem = new Problem();
            problem.Id = -1;
            problem.Description = "Mock New Problem";
            problem.Title = "Mock New Problem";
            problem.States.Add(BuildRegisterState());
            problem.Units.Add(BuildUnit());
            return problem;
        }

        public static Problem RegisterStateToTechnicalCommitteeState(Problem problem,IEnumerable<Unit> technicalCommittes)
        {
            var untiRepo = ObjectMother.GetUnitRepository();
            var stateInfo = new StateChangeInfo() { RecieverUnits = technicalCommittes.ToList() };            
            problem.Request(stateInfo);
            return problem;
        }        
    }
}
