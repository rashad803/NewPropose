using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewPropose.Models
{
    public class Inbox : IIdentifier
    {
        public Inbox()
        {
            Documents = new List<Problem>();
        }
        public int Id { get; set; }
        public virtual Unit Owner { get; set; }
        public virtual List<Problem> Documents { get; set; }
    }
}
