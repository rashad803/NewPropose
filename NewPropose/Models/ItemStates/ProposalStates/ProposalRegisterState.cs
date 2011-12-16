using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPropose.Models.ItemStates.ProposalStates
{
    public class ProposalRegisterState : ProposalState
    {
        

        public override void Handle(Proposal context, StateChangeInfo stateChangeInfo)
        {
            var comment = new Comment();
            comment.Description = stateChangeInfo.Description;
            comment.Reason = stateChangeInfo.Reason;
            comment.Employee = stateChangeInfo.EmployeeHandler;
            comment.IsAccepted = stateChangeInfo.IsAccepted;
            comment.Problem = context.Problem;
            comment.Proposal = context;
            comment.Unit = stateChangeInfo.UnitHandler;
            Comments.Add(comment);

            if (HaveAllUnitsGivenOpinion(context))
            {
                var result = false;
                Comments.ForEach(c => result = result || c.IsAccepted);
                if (result)
                {
            
                    IsCurrent = false;
                    var newState = new ProposalSuperCommitteeState();
                    newState.IsCurrent = true;
                    context.States.Add(newState);
                }
                else
                {
               
                    IsCurrent = false;
                    var newState = new ProposalCancelState();
                    newState.IsCurrent = true;
                    context.States.Add(newState);
                }
            }          
        }

        private bool HaveAllUnitsGivenOpinion(Proposal context)
        {
            var result = true;
            context.Problem.Receivers.ForEach(inbox => result = result && Comments.Any(c => c.Unit.Id == inbox.Owner.Id) );
            return result;
        }
    }
}