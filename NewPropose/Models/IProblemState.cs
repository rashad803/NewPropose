using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewPropose.Models
{
    public interface IProblemState : IIdentifier
    {
        Problem Owner { get; set; }
        Employee EmployeeHandler { get; set; }
        Unit UnitHandler { get; set; }
    }
}
