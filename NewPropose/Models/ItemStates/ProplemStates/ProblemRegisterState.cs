using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPropose.Models.ItemStates.ProplemStates
{
    public class ProblemRegisterState : ProblemState
    {
        public override void Handle(Problem context, StateChangeInfo stateChangeInfo)
        {
            var newState = new ProblemTechnicalCommitteeState();
            newState.IsCurrent = true;
            context.CurrentState.IsCurrent = false;
            context.States.Add(newState);
            context.Receivers.AddRange(stateChangeInfo.RecieverUnits.Select(u => u.Inbox));
            stateChangeInfo.RecieverUnits.ToList().ForEach(unit => unit.Inbox.Documents.Add(context));
        }
    }
}