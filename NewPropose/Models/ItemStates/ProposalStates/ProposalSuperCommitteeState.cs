using System;

namespace NewPropose.Models.ItemStates.ProposalStates
{
    public class ProposalSuperCommitteeState : ProposalState
    {
        public override void Handle(Proposal context, StateChangeInfo stateChangeInfo)
        {
            var comment = new Comment
                              {
                                  Description = stateChangeInfo.Description,
                                  Reason = stateChangeInfo.Reason,
                                  Problem = context.Problem,
                                  Proposal = context,
                                  Unit = stateChangeInfo.UnitHandler,
                                  IsAccepted = stateChangeInfo.IsAccepted
                              };
            Comments.Add(comment);
            if(stateChangeInfo.IsAccepted)
            {
                IsCurrent = false;
                var newState = new ProposalAcceptedState();
                newState.IsCurrent = true;
                context.States.Add(newState);
                context.Problem.Request(stateChangeInfo);
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
}