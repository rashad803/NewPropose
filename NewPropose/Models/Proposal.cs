using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using NewPropose.Models.ItemStates;

namespace NewPropose.Models
{
    public class Proposal : IIdentifier
    {
        public Proposal()
        {
            Comments = new List<Comment>();
            States = new List<ProposalState>();
            Created = DateTime.Now;
        }
        public int Id { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<ProposalState> States { get; set; }
        public Employee  Creator { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public Problem Problem { get; set; }
        [NotMapped]
        public ProposalState CurrentState { get { return States.Single(s => s.IsCurrent == true); } private set { } }
        public void Request(StateChangeInfo stateChangeInfo)
        {
            CurrentState.Handle(this, stateChangeInfo);
        }
    }
}
