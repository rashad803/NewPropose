using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewPropose.Models
{
    public abstract class ProposeState : IIdentifier
    {
        public int Id { get; set; }
        public virtual Proposal Owner { get; set; }
        public virtual Employee EmployeeHandler { get; set; }
        public virtual Unit UnitHandler { get; set; }

        public abstract void Register(Proposal Item);
        public abstract void Confirm(Proposal Item);
        public abstract void Cancel(Proposal Item);
    }
}
