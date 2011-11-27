using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewPropose.Models.Units
{
    public class OUGroup : IIdentifier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public virtual List<OrganizationUnit> OUList { get; set; }
    }
}
