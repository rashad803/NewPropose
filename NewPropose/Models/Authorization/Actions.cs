using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPropose.Models.Authorization
{
    public class Actions : IIdentifier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OrgName { get; set; }
        public Controls control { get; set; }
        public int ControlsId { get; set; }
    }
}