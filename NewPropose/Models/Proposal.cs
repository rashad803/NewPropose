using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewPropose.Models
{
    public class Proposal : IIdentifier
    {
        public int Id { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
