using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using NewPropose.Models;
using NewPropose.Models.ItemStates.ProplemStates;
using NewPropose.Models.ItemStates;

namespace NewProposeTest
{
    
    public class TestProblemState
    { 
        [Fact]
        public void ProblemShouldHaveRegisterStatWhenCreated()
        {
            var repo = ObjectMother.GetProblemRepository();
            var problem = repo.Create(ObjectMother.GetUnit());
            Assert.Equal(problem.CurrentState.GetType(), typeof(RegisterState));
        }

        [Fact]
        public void ProblemShouldHaveOwnerWhenCreated()
        {
            var repo = ObjectMother.GetProblemRepository();
            var problem = repo.Create(ObjectMother.GetUnit());
            Assert.Equal(problem.Units.Count, 1);
        }

        [Fact]
        public void SecretariatUnitShouldBeAbleToSendNewProblemToArbitararyUnits()
        {
            var untiRepo = ObjectMother.GetUnitRepository();
            var technicalCommitte = untiRepo.GetAllTechnicalCommites().First();
            var stateInfo = new StateChangeInfo() { RecieverUnits = new List<Unit>() { technicalCommitte } };
            var repo = ObjectMother.GetProblemRepository();
            var justReceivedProblem = repo.GetNewProblems().First();
            justReceivedProblem.Request(stateInfo);
            Assert.Equal(justReceivedProblem.CurrentState.GetType(), typeof(TechnicalCommitteeState));
        }

        [Fact]
        public void TechnicalCommitiesShouldBeAbleToSeeProblemsWithTechnicalCommiteState()
        {
            var untiRepo = ObjectMother.GetUnitRepository();
            var technicalCommitte = untiRepo.GetAllTechnicalCommites().First();
            var stateInfo = new StateChangeInfo() { RecieverUnits = new List<Unit>() { technicalCommitte } };
            var problemRepo = ObjectMother.GetProblemRepository();
            var justReceivedProblem = problemRepo.GetNewProblems().First();
            justReceivedProblem.Request(stateInfo);
            var res = technicalCommitte.Inbox.Documents.Any(doc => doc.Id == -1);
            Assert.True(res);
        }

        [Fact]
        public void PeopleShouldBeAbleToSeeAllProblemsWithTechnicalCommiteState()
        {
            var untiRepo = ObjectMother.GetUnitRepository();
            var technicalCommitte = untiRepo.GetAllTechnicalCommites().First();
            var stateInfo = new StateChangeInfo() { RecieverUnits = new List<Unit>() { technicalCommitte } };
            var problemRepo = ObjectMother.GetProblemRepository();
            var justReceivedProblem = problemRepo.GetNewProblems().First();
            justReceivedProblem.Request(stateInfo);
            var problemCounts = problemRepo.GetAllForEmployees().Count();
            Assert.NotEqual(problemCounts, 0);
        }

    }
}
