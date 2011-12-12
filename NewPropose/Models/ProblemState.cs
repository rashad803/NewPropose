using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewPropose.Models.ItemStates;

namespace NewPropose.Models
{
    public abstract class ProblemState : IIdentifier
    {
        public ProblemState()
        {
            Created = DateTime.Now;
        }
        public int Id { get; set; }
        public bool IsCurrent { get; set; }
        public virtual Problem Owner { get; set; }
        public virtual Employee EmployeeHandler { get; set; }
        public virtual Unit UnitHandler { get; set; }
        public DateTime Created { get; set; } 
        public abstract void Handle(Problem context,StateChangeInfo stateChangeInfo);
    }
}
