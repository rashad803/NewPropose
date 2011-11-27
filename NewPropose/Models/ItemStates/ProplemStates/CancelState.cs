using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPropose.Models.ItemStates.ProplemStates
{
    public class CancelState : ProblemState
    {
        public override void Register(Problem Item)
        {
            throw new NotImplementedException();
        }

        public override void Confirm(Problem Item)
        {
            throw new NotImplementedException();
        }

        public override void Cancel(Problem Item)
        {
            throw new NotImplementedException();
        }

        public override void Handle(Problem context, StateChangeInfo stateChangeInfo)
        {
            throw new NotImplementedException();
        }
    }
}