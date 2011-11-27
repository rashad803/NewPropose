using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewPropose.Models
{
    public class Outbox : IIdentifier
    {
        public int Id { get; set; }
        public virtual Employee Owner { get; set; }
        public virtual List<Problem> Documents { get; set; }
    }
}
