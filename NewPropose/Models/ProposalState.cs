using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewPropose.Models.ItemStates;

namespace NewPropose.Models
{
    public abstract class ProposalState : IIdentifier
    {
        public ProposalState()
        {
            Created = DateTime.Now;
        }
        public int Id { get; set; }
        public bool IsCurrent { get; set; }
        public virtual Proposal Owner { get; set; }
        public virtual Employee EmployeeHandler { get; set; }
        public DateTime Created { get; set; }

        public abstract void Handle(Proposal context, StateChangeInfo stateChangeInfo);

        public virtual Unit UnitHandler { get; set; }

        //public abstract void Register(Proposal Item);
        //public abstract void Confirm(Proposal Item);
        //public abstract void Cancel(Proposal Item);
    }
}
