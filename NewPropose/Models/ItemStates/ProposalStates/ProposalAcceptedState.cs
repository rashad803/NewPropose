using System;

namespace NewPropose.Models.ItemStates.ProposalStates
{
    public class ProposalAcceptedState : ProposalState
    {
        public override void Handle(Proposal context, StateChangeInfo stateChangeInfo)
        {
            throw new NotImplementedException();
        }
    }
}