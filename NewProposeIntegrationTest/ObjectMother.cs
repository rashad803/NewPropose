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

        public static void BuildProblem()
        {
            var problem = GetProblemRepository().Create(new Unit() { Name = "Test Unit" });
            problem.Description = "Test New Problem";
            problem.Title = "Test New Problem";
            ObjectMother.GetProblemRepository().Add(problem);
        }

        public static ProblemRegisterState BuildRegisterState()
        {
            var registerState = new ProblemRegisterState() { IsCurrent = true };
            return registerState;
        }

        public static void BuildTechnicalCommites()
        {
            var unitRepo = ObjectMother.GetUnitRepository();
            unitRepo.Add(unitRepo.CreateTechnicalCommite("Test tech unit 1"));
            unitRepo.Add(unitRepo.CreateTechnicalCommite("Test tech unit 2"));
        }

        public static void BuildEmployee()
        {
            var repository = GetEmployeeRepository();
            var employee = repository.Create();
            employee.FirstName = "Test First Name";
            employee.LastName = "Test Last Name";
            employee.UserName = "Test User Name";
            repository.Add(employee);
        }

        public static Problem BuildProblemAndChangeStateToTechnicalCommitie()
        {
            ObjectMother.Initialize();
            ObjectMother.BuildTechnicalCommites();
            ObjectMother.BuildProblem();
            ObjectMother.GetUnitOrWork().Commit();
            var techUnit = ObjectMother.GetUnitRepository().GetAllTechnicalCommites().First();

            var stateInfo = new StateChangeInfo();
            stateInfo.RecieverUnits.Add(techUnit);

            var justReceivedProblem = ObjectMother.GetWorkflowService().GetNewProblems().First();
            justReceivedProblem.Request(stateInfo);
            return justReceivedProblem;
        }
    }
}