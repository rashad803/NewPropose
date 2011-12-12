using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewPropose.Models;
using NewPropose.Models.ItemStates;
using NewPropose.Models.ItemStates.ProplemStates;
using Xunit;
using Xunit.Extensions;
using NewPropose.Models.ItemStates.ProposalStates;

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
            var problem = ObjectMother.BuildProblemAndChangeStateToTechnicalCommittee();
            Assert.Equal(problem.CurrentState.GetType(), typeof(ProblemTechnicalCommitteeState));
        }

        [Fact]
        [AutoRollback]
        public void TechnicalCommitteesShouldBeAbleToSeeProblemsWithTechnicalCommitteeState()
        {
            ObjectMother.BuildProblemAndChangeStateToTechnicalCommittee();
            var res = ObjectMother.GetUnitRepository().GetAllTechnicalCommittees().First().Inbox.Documents.Count == 1;
            Assert.True(res);
        }


        [Fact]
        [AutoRollback]
        public void TechnicalCommitteesShouldNotBeAbleToSeeAllProblemsWithTechnicalCommitteeState()
        {
            ObjectMother.BuildProblemAndChangeStateToTechnicalCommittee();
            var res = ObjectMother.GetUnitRepository().GetAllTechnicalCommittees().Last().Inbox.Documents.Count == 0;
            Assert.True(res);
        }

        [Fact]
        [AutoRollback]
        public void PeopleShouldBeAbleToSeeAllProblemsWithTechnicalCommitteeState()
        {
            var countBefore = ObjectMother.GetWorkflowService().GetPeopleProblems().Count();
            ObjectMother.BuildProblemAndChangeStateToTechnicalCommittee();
            var problemsThatPeopleCanSee = ObjectMother.GetWorkflowService().GetPeopleProblems();
            Assert.NotEqual(problemsThatPeopleCanSee.Count(), countBefore + 1);
        }

        [Fact]
        [AutoRollback]
        public void AnEmployeeShouldBeAbleToMakeAProposeForEachProblem()
        {
            ObjectMother.BuildProblemAndChangeStateToTechnicalCommittee();
            ObjectMother.BuildEmployee();
            ObjectMother.GetUnitOrWork().Commit();

            var selectedProblem = ObjectMother.GetWorkflowService().GetPeopleProblems().First();
            var employee = ObjectMother.GetEmployeeRepository().GetAll().First();


            var countBefore = selectedProblem.Proposals.Count;

            var proposal = ObjectMother.GetProposalRepository().Create();
            employee.MakeProposal(selectedProblem, proposal, "Test Subject", "Test Content");
            ObjectMother.GetUnitOrWork().Commit();

            selectedProblem = ObjectMother.GetProblemRepository().Load(selectedProblem.Id);
            Assert.Equal(countBefore + 1, selectedProblem.Proposals.Count);
        }

        [Fact]
        [AutoRollback]
        public void EmployeesShouldBeAbleToMakeAProposeForAProblem()
        {
            ObjectMother.BuildProblemAndChangeStateToTechnicalCommittee();
            ObjectMother.BuildEmployee();
            ObjectMother.BuildEmployee();
            ObjectMother.GetUnitOrWork().Commit();

            var selectedProblem = ObjectMother.GetWorkflowService().GetPeopleProblems().First();
            var firstEmployee = ObjectMother.GetEmployeeRepository().GetAll().First();
            var lastEmployee = ObjectMother.GetEmployeeRepository().GetAll().Last();

            var countBefore = selectedProblem.Proposals.Count;

            var fistProposal = ObjectMother.GetProposalRepository().Create();
            var secondProposal = ObjectMother.GetProposalRepository().Create();
            firstEmployee.MakeProposal(selectedProblem, fistProposal, "Test Subject 1", "Test Content 1");
            lastEmployee.MakeProposal(selectedProblem, secondProposal, "Test Subject 2", "Test Content 2");

            ObjectMother.GetUnitOrWork().Commit();

            selectedProblem = ObjectMother.GetProblemRepository().Load(selectedProblem.Id);
            Assert.Equal(countBefore + 2, selectedProblem.Proposals.Count);
        }

        [Fact]
        [AutoRollback]
        public void TechnicalCommitteeeMemberShouldBeAbleToSeeAllProblemsProposals()
        {
            ObjectMother.Initialize();
            ObjectMother.BuildTechnicalCommittees();
            ObjectMother.BuildProblem();
            ObjectMother.GetUnitOrWork().Commit();
            var techUnit = ObjectMother.GetUnitRepository().GetAllTechnicalCommittees().First();

            var stateInfo = new StateChangeInfo();
            stateInfo.RecieverUnits.Add(techUnit);

            var problem = ObjectMother.GetWorkflowService().GetNewProblems().First();
            problem.Request(stateInfo);

            var proposal = ObjectMother.BuildProposal(problem);
            ObjectMother.GetUnitOrWork().Commit();
            techUnit = ObjectMother.GetUnitRepository().GetAllTechnicalCommittees().First();

            Assert.True(techUnit.Inbox.Documents.Single(p => p.Id == problem.Id).Proposals.Any(pr => pr.Id == proposal.Id));
        }

        [Fact]
        [AutoRollback]
        public void TechnicalCommitteeShouldBeAbleToGiveOpinion()
        {
            ObjectMother.Initialize();
            ObjectMother.BuildTechnicalCommittees();
            ObjectMother.GetUnitOrWork().Commit();
            var techCommittees = ObjectMother.GetUnitRepository().GetAllTechnicalCommittees();
            var problem = ObjectMother.BuildProblemAndChangeStateToTechnicalCommittee(techCommittees.ToList());
            var proposal = ObjectMother.BuildProposal(problem);
            ObjectMother.GetUnitOrWork().Commit();
            var tc = techCommittees.First();
            var changeInfo = new StateChangeInfo();
            changeInfo.Description = "Test Description";
            changeInfo.Reason = "Test Reason";
            changeInfo.IsAccepted = false;
            changeInfo.Committee = tc;
            changeInfo.EmployeeHandler = tc.Members.First();
            changeInfo.UnitHandler = tc;
            proposal.Request(changeInfo);
            ObjectMother.GetUnitOrWork().Commit();
            Assert.Equal(1, proposal.CurrentState.Comments.Count);
            Assert.Equal(typeof(ProposalRegisterState), proposal.CurrentState.GetType());
        }


    }
}