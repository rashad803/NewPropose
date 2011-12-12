using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewPropose.DataAccess;
using NewPropose.DataAccess.IRepository;
using NewPropose.DataAccess.Repository;
using NewPropose.Models;
using NewPropose.Models.ItemStates.ProplemStates;
using NewPropose.Models.Services;
using NewPropose.Models.Services.Imp;
using System.Data.Entity;
using NewPropose.Models.ItemStates;

namespace NewProposeIntegrationTest
{
    public static class ObjectMother
    {
        private static IDatabaseFactory _databaseFactory;
        static ObjectMother()
        {
            _databaseFactory = new DatabaseFactory();
            var context = _databaseFactory.Get();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProposeEntities>());
        }

        public static void Initialize()
        {
            _databaseFactory = new DatabaseFactory();
        }

        public static IUnitOfWork GetUnitOrWork()
        {
            return new UnitOfWork(_databaseFactory);
        }

        public static IProblemRepository GetProblemRepository()
        {
            return new ProblemRepository(_databaseFactory);
        }

        public static IProblemStateRepository GetProblemStateRepository()
        {
            return new ProblemStateRepository(_databaseFactory);
        }

        public static IUnitRepository GetUnitRepository()
        {
            return new UnitRepository(_databaseFactory);
        }

        public static IWorkflowService GetWorkflowService()
        {
            return new WorkflowService(GetProblemRepository(), GetProblemStateRepository());
        }

        public static IEmployeeRepository GetEmployeeRepository()
        {
            return new EmployeeRepository(_databaseFactory);
        }

        public static IProposalRepository GetProposalRepository()
        {
            return new ProposalRepository(_databaseFactory);
        }

        public static Problem BuildProblem()
        {
            var problem = GetProblemRepository().Create(new Unit() { Name = "Test Unit" });
            problem.Description = "Test New Problem";
            problem.Title = "Test New Problem";
            ObjectMother.GetProblemRepository().Add(problem);
            return problem;
        }

        public static ProblemRegisterState BuildRegisterState()
        {
            var registerState = new ProblemRegisterState() { IsCurrent = true };
            return registerState;
        }

        public static void BuildTechnicalCommittees()
        {
            var unitRepo = ObjectMother.GetUnitRepository();
            var unit = unitRepo.CreateTechnicalCommittee("Test tech unit 1");
            unit.Members.Add(BuildEmployee());
            unit.Members.Add(BuildEmployee());
            unitRepo.Add(unit);
            GetUnitOrWork().Commit();

            unit = unitRepo.CreateTechnicalCommittee("Test tech unit 2");
            unit.Members.Add(BuildEmployee());
            unit.Members.Add(BuildEmployee());
            unitRepo.Add(unit);
            GetUnitOrWork().Commit();

            unit = unitRepo.CreateTechnicalCommittee("Test tech unit 3");
            unit.Members.Add(BuildEmployee());
            unit.Members.Add(BuildEmployee());
            unitRepo.Add(unit);
            GetUnitOrWork().Commit();
        }

        public static Employee BuildEmployee()
        {
            var repository = GetEmployeeRepository();
            var employee = new Employee();
            employee.FirstName = "Test First Name";
            employee.LastName = "Test Last Name";
            employee.UserName = "Test User Name";
            repository.Add(employee);
            return employee;
        }

        public static Problem BuildProblemAndChangeStateToTechnicalCommittee()
        {
            ObjectMother.Initialize();
            ObjectMother.BuildTechnicalCommittees();
            ObjectMother.BuildProblem();
            ObjectMother.GetUnitOrWork().Commit();
            var techUnit = ObjectMother.GetUnitRepository().GetAllTechnicalCommittees().First();

            var stateInfo = new StateChangeInfo();
            stateInfo.RecieverUnits.Add(techUnit);

            var justReceivedProblem = ObjectMother.GetWorkflowService().GetNewProblems().First();
            justReceivedProblem.Request(stateInfo);
            return justReceivedProblem;
        }

        public static Problem BuildProblemAndChangeStateToTechnicalCommittee(List<Unit> technicalCommittees)
        {
            ObjectMother.Initialize();

            var stateInfo = new StateChangeInfo();
            technicalCommittees.ForEach(tc => stateInfo.RecieverUnits.Add(tc));
            ObjectMother.GetUnitOrWork().Commit();
            var justReceivedProblem = ObjectMother.BuildProblem();
            justReceivedProblem.Request(stateInfo);
            return justReceivedProblem;
        }

        public static Proposal BuildProposal(Problem problem)
        {
            var employee = BuildEmployee();
            var proposal = GetProposalRepository().Create();
            employee.MakeProposal(problem, proposal, "Test Subject 1", "Test Content 1");
            return proposal;
        }
    }
}