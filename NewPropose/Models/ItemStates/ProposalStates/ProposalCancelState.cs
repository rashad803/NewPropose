﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPropose.Models.ItemStates.ProposalStates
{
    public class ProposalCancelState : ProposalState
    {  
        public override void Handle(Proposal context, StateChangeInfo stateChangeInfo)
        {
            throw new NotImplementedException();
        }
    }
}