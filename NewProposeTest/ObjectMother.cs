using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Moq;
using NewPropose.DataAccess.IRepository;
using NewPropose.Models.ItemStates.ProplemStates;
using NewPropose.Models;

namespace NewProposeTest
{
    public static class ObjectMother
    {
        public static IProblemRepository GetProblemRepository()
        {
            var m = new Mock<IProblemRepository>();
            m.Setup(repo => repo.Create(It.IsAny<Unit>())).Returns(NewProblem());
            var newProblems = new List<Problem>() { NewProblem() };
            m.Setup(repo => repo.GetNewProblems()).Returns(newProblems);
            return m.Object;
        }

        public static IUnitRepository GetUnitRepository()
        {
            var m = new Mock<IUnitRepository>();
            var unit = GetUnit();
            unit.Type = "TechnicalCommite";
            m.Setup(repo => repo.GetAllTechnicalCommites()).Returns(new List<Unit>() { unit });
            return m.Object;
        }

        public static Unit GetUnit()
        {
            var unit = new Unit() { Name = "Mock Unit" };            
            return unit;
        }

        public static RegisterState RegisterState()
        {
            var registerState = new RegisterState() { IsCurrent = true };
            return registerState;
        }

        public static Problem NewProblem()
        {
            var problem = new Problem();
            problem.Id = -1;
            problem.Description = "Mock New Problem";
            problem.Title = "Mock New Problem";
            problem.States.Add(RegisterState());
            problem.Units.Add(GetUnit());
            return problem;
        }

    }
}
