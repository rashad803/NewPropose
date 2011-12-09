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
            ObjectMother.Initialize();
            var repo = ObjectMother.GetProblemRepository();
            var beforeCount = repo.GetAll().Count;
            ObjectMother.BuildProblem();                                
            var uow = ObjectMother.GetUnitOrWork();
            uow.Commit();
            var afterCount = repo.GetAll().Count;
            Assert.Equal(afterCount, beforeCount + 1);
        }

        [Fact]
        [AutoRollback]
        public void SecretariatUnitShouldBeAbleToSendNewProblemToArbitararyUnits()
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
            Assert.Equal(justReceivedProblem.CurrentState.GetType(), typeof(TechnicalCommitteeState));
        }

        [Fact]
        [AutoRollback]
        public void TechnicalCommitiesShouldBeAbleToSeeProblemsWithTechnicalCommiteState()
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
            var res = ObjectMother.GetUnitRepository().GetAllTechnicalCommites().First().Inbox.Documents.Count == 1;
            Assert.True(res);
        }


        [Fact]
        [AutoRollback]
        public void TechnicalCommitiesShouldNotBeAbleToSeeAllProblemsWithTechnicalCommiteState()
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
            var res = ObjectMother.GetUnitRepository().GetAllTechnicalCommites().Last().Inbox.Documents.Count == 0;
            Assert.True(res);
        }




    }
}
