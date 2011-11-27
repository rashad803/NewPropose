using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewPropose.Models.Builder
{
    public interface IBuilder
    {
        WorkFlow CreateWorkFlow(Unit un, Employee emp);
    }
}
