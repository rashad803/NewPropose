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
        
        public static Problem BuildProblem()
        {

            var problem = GetProblemRepository().Create(BuildUnit());
            problem.Description = "Mock New Problem";
            problem.Title = "Mock New Problem";                
            return problem;
        }


        public static Unit BuildUnit()
        {
            var unit = new Unit() { Name = "Mock Unit" };
            return unit;
        }

        public static RegisterState BuildRegisterState()
        {
            var registerState = new RegisterState() { IsCurrent = true };
            return registerState;
        }
    }
}
