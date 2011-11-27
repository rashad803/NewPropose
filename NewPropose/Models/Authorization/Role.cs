using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPropose.Models.Authorization
{
    public class Role : IIdentifier
    {

        public int Id { get; set; }
        public string Name { get; set; }
        private List<Controls> controls = new List<Controls>();
        public virtual List<Controls> Controls { get { return controls; } set { controls = value; } }

        private List<Employee> employees = new List<Employee>();
        public virtual List<Employee> Employees { get { return employees; } set { employees = value; } }
    }
}