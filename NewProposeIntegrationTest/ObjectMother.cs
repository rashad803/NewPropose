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

namespace NewProposeIntegrationTest
{
    public static class ObjectMother
    {
        private static IDatabaseFactory _databaseFactory;
        static ObjectMother()
        {
            _databaseFactory = new DatabaseFactory();
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

        public static  IProblemStateRepository GetProblemStateRepository()
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
        
        public static void BuildProblem()
        {
            var problem = GetProblemRepository().Create(new Unit() { Name = "Mock Unit" });
            problem.Description = "Mock New Problem";
            problem.Title = "Mock New Problem";
            ObjectMother.GetProblemRepository().Add(problem);         
        }

        public static RegisterState BuildRegisterState()
        {
            var registerState = new RegisterState() { IsCurrent = true };
            return registerState;
        }

        public static void BuildTechnicalCommites()
        {      
            var unitRepo = ObjectMother.GetUnitRepository();
            unitRepo.Add(unitRepo.CreateTechnicalCommite("Mock tech unit 1"));
            unitRepo.Add(unitRepo.CreateTechnicalCommite("Mock tech unit 2"));            
        }             
    }
}
