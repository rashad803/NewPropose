using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPropose.Models
{
    public class Comment : IIdentifier
    {
        public int Id { get; set; }
        public virtual Problem Problem { get; set; }
        public virtual Proposal Proposal { get; set; }
        public bool IsAccepted { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Unit Unit { get; set; }
    }
}