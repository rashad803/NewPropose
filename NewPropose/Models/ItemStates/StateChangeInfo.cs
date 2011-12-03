using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPropose.Models.ItemStates
{
    public class StateChangeInfo
    {
        public StateChangeInfo()
        {
            RecieverUnits = new List<Unit>();
        }
        public IList<Unit> RecieverUnits { get; set; }
    }
}