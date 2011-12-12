using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewPropose.Models
{
    public class Unit : IIdentifier
    {
        public Unit()
        {
            Inbox = new Inbox();
            Problems = new List<Problem>();
            Members = new List<Employee>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual List<Employee> Members { get; set; }
        public virtual Inbox Inbox { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Problem> Problems { get; set; }
        public string Type { get; set; }
    }
}
