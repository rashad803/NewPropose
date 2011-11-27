using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPropose.Models.Authorization
{
    public class Controls : IIdentifier
    {
        public int Id { get; set; }
        public bool FullControl { get; set; }
        public string Name { get; set; }
        public string OrgName { get; set; }
        private List<Actions> action = new List<Actions>();
        public virtual List<Actions> Actions { get { return action; } set { action = value; } }
        private List<Role> roles = new List<Role>();
        public virtual List<Role> Roles { get { return roles; } set { roles = value; } }
    }
}