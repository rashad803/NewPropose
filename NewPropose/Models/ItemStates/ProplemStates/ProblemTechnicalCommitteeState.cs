using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPropose.Models.ItemStates.ProplemStates
{
    public class ProblemTechnicalCommitteeState : ProblemState
    {
        public override void Handle(Problem context,StateChangeInfo stateChangeInfo)
        {
            var newState = new ProblemAcceptedState();
            newState.IsCurrent = true;
            context.CurrentState.IsCurrent = false;
            context.States.Add(newState);           
        }
    }
}