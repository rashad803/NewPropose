﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using NewPropose.Models;
using NewPropose.Models.ItemStates.ProplemStates;
using NewPropose.Models.ItemStates;
using NewPropose.Models.ItemStates.ProposalStates;

namespace NewProposeTest
{
    
    public class ProblemTest
    { 
        [Fact]
        public void ProblemShouldHaveRegisterStatWhenCreated()
        {
            var repo = ObjectMother.GetProblemRepository();
            var problem = repo.Create(ObjectMother.BuildUnit());
            Assert.Equal(problem.CurrentState.GetType(), typeof(ProblemRegisterState));
        }

        [Fact]
        public void ProblemShouldHaveOwnerWhenCreated()
        {
            var repo = ObjectMother.GetProblemRepository();
            var problem = repo.Create(ObjectMother.BuildUnit());
            Assert.NotNull(problem.Creator);
        }

        [Fact]
        public void SecretariatUnitShouldBeAbleToSendNewProblemToArbitararyUnits()
        {
            var technicalCommittes = ObjectMother.GetUnitRepository().GetAllTechnicalCommittees();
            var justReceivedProblem = ObjectMother.GetWorkflowService().GetNewProblems().First();           
            var transferdProblem = ObjectMother.RegisterStateToTechnicalCommitteeState(justReceivedProblem, technicalCommittes);
            Assert.Equal(transferdProblem.CurrentState.GetType(), typeof(ProblemTechnicalCommitteeState));
        }

        [Fact]
        public void TechnicalCommitteesShouldBeAbleToSeeProblemsWithTechnicalCommitteeState()
        {
            var technicalCommittes = ObjectMother.GetUnitRepository().GetAllTechnicalCommittees();
            var justReceivedProblem = ObjectMother.GetWorkflowService().GetNewProblems().First();
            ObjectMother.RegisterStateToTechnicalCommitteeState(justReceivedProblem,technicalCommittes);
            var res = technicalCommittes.First().Inbox.Documents.Any(doc => doc.Id == -1);
            Assert.True(res);
        }

        [Fact]
        public void PeopleShouldBeAbleToSeeAllProblemsWithTechnicalCommitteeState()
        {
            var technicalCommittes = ObjectMother.GetUnitRepository().GetAllTechnicalCommittees();
            var justReceivedProblem = ObjectMother.GetWorkflowService().GetNewProblems().First();
            ObjectMother.RegisterStateToTechnicalCommitteeState(justReceivedProblem, technicalCommittes);
            var workflowService = ObjectMother.GetWorkflowService();
            var problemsThatPeopleCanSee = workflowService.GetPeopleProblems();           
            Assert.NotEqual(problemsThatPeopleCanSee.Count(), 0);
        }

        [Fact]
        public void ProposalShouldHaveRegisterStatWhenCreated()
        {
            var repo = ObjectMother.GetProposalRepository();  
            var proposal = repo.Create();
            Assert.Equal(typeof(ProposalRegisterState), proposal.CurrentState.GetType());
        }


    }
}
