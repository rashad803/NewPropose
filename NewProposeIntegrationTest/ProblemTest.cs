using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewPropose.Models;
using NewPropose.Models.ItemStates;
using NewPropose.Models.ItemStates.ProplemStates;
using Xunit;
using Xunit.Extensions;

namespace NewProposeIntegrationTest
{
    public class ProblemTest
    {

        //[Fact]
        //public void CreateDb()
        //{
        //    var repo = ObjectMother.GetProblemRepository();
        //    var beforeCount = repo.GetAll().Count;
        //}

        [Fact]
        [AutoRollback]
        public void ShouldBeAbleToCreateNewProblem()
        {
            var problem = ObjectMother.BuildProblem();
            var repo = ObjectMother.GetProblemRepository();
            var beforeCount = repo.GetAll().Count;
            repo.Add(problem);
            var uow = ObjectMother.GetUnitOrWork();
            uow.Commit();
            var afterCount = repo.GetAll().Count;
            Assert.Equal(afterCount, beforeCount + 1);
        }

        [Fact]
        [AutoRollback]
        public void SecretariatUnitShouldBeAbleToSendNewProblemToArbitararyUnits()
        {
            var unitRepo = ObjectMother.GetUnitRepository();
            var techUnit = unitRepo.CreateTechnicalCommite("Mock tech unit");
            

            var problem = ObjectMother.BuildProblem();
            var repo = ObjectMother.GetProblemRepository();            
            repo.Add(problem);
            ObjectMother.GetUnitOrWork().Commit();

            var stateInfo = new StateChangeInfo();
            stateInfo.RecieverUnits.Add(techUnit);

            var justReceivedProblem = ObjectMother.GetWorkflowService().GetNewProblems().First();
            justReceivedProblem.Request(stateInfo);
            Assert.Equal(justReceivedProblem.CurrentState.GetType(), typeof(TechnicalCommitteeState));
        }
    }
}
