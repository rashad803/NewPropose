using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewPropose.Models.Authorization;

namespace NewPropose.Models
{
    public class Employee : IIdentifier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual Role Role { get; set; }
        public virtual Outbox Outbox { get; set; }
        public virtual List<Comment> Comments { get; set; }

        public virtual Unit Unit { get; set; }

        public virtual int ExecutedProposal { get; set; }

        public virtual EmployeeType EmpLoyeeType { get; set; }

        public virtual string Job { get; set; }
        public virtual string Education { get; set; }

        public virtual string FullName
        {
            get { return Name + " " + LastName; }
        }

        //private IList<Draft> drafts = new List<Draft>();
        //public virtual IList<Draft> Drafts
        //{
        //    get { return drafts; }
        //    set { drafts = value; }
        //}

    }
}