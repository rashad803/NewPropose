﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NewPropose.Models.ItemStates;

namespace NewPropose.Models
{
    public class Problem : IIdentifier
    {
        public Problem()
        {
            States = new List<ProblemState>();
            Receivers = new List<Inbox>();
            Proposals = new List<Proposal>();
            Active = true;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public Unit Creator { get; set; }
        public virtual List<Proposal> Proposals { get; set; }      
        public virtual List<ProblemState> States { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Inbox> Receivers { get; set; }
        [NotMapped]
        public ProblemState CurrentState { get { return States.Single(s => s.IsCurrent == true);} private set{} }

        public void Request(StateChangeInfo stateChangeInfo)
        {
            CurrentState.Handle(this,stateChangeInfo);
        }
    }
}