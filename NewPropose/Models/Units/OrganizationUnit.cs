using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPropose.Models.Units
{
    public class OrganizationUnit : IIdentifier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PersonnelNumber { get; set; }
        public virtual OUGroup Group { get; set; }
        public int Code { get; set; }
        public int Sort { get; set; }
        public virtual List<Problem> Problems { get; set; }
    }
}