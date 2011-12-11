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
            var problem = ObjectMother.BuildProblemAndChangeStateToTechnicalCommitie();
            Assert.Equal(problem.CurrentState.GetType(), typeof(ProblemTechnicalCommitteeState));
        }

        [Fact]
        [AutoRollback]
        public void TechnicalCommitiesShouldBeAbleToSeeProblemsWithTechnicalCommiteState()
        {
            ObjectMother.BuildProblemAndChangeStateToTechnicalCommitie();
            var res = ObjectMother.GetUnitRepository().GetAllTechnicalCommites().First().Inbox.Documents.Count == 1;
            Assert.True(res);
        }


        [Fact]
        [AutoRollback]
        public void TechnicalCommitiesShouldNotBeAbleToSeeAllProblemsWithTechnicalCommiteState()
        {
            ObjectMother.BuildProblemAndChangeStateToTechnicalCommitie();
            var res = ObjectMother.GetUnitRepository().GetAllTechnicalCommites().Last().Inbox.Documents.Count == 0;
            Assert.True(res);
        }

        [Fact]
        [AutoRollback]
        public void PeopleShouldBeAbleToSeeAllProblemsWithTechnicalCommiteState()
        {
            var countBefore = ObjectMother.GetWorkflowService().GetPeopleProblems().Count();
            ObjectMother.BuildProblemAndChangeStateToTechnicalCommitie();
            var problemsThatPeopleCanSee = ObjectMother.GetWorkflowService().GetPeopleProblems();
            Assert.NotEqual(problemsThatPeopleCanSee.Count(), countBefore + 1);
        }

        [Fact]
        [AutoRollback]
        public void PeopleShouldBeAbleToMakeAProposeForEachProblem()
        {
            ObjectMother.BuildProblemAndChangeStateToTechnicalCommitie();
            var problemsThatPeopleCanSee = ObjectMother.GetWorkflowService().GetPeopleProblems();
            ObjectMother.BuildEmployee();
            ObjectMother.GetUnitOrWork().Commit();
            var employee = ObjectMother.GetEmployeeRepository().GetAll().First();
            var selectedProblem = problemsThatPeopleCanSee.First();

            var countBefore = selectedProblem.Proposals.Count;

            var proposal = ObjectMother.GetProposalRepository().Create();
            employee.MakeProposal(selectedProblem, proposal, "Test Subject", "Test Content");
            ObjectMother.GetUnitOrWork().Commit();

            selectedProblem = problemsThatPeopleCanSee.First();
            Assert.Equal(countBefore + 1, selectedProblem.Proposals.Count);
        }


    }
}