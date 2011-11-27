using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewPropose.Models.Builder
{
    public class FirstBuilder : IBuilder
    {
        public WorkFlow CreateWorkFlow(Unit un, Employee emp)
        {
            //Unit ParentUnit = null;
            //if (un.UnitType.UnitLevel != UnitLevel.Council)
            //{
            //    ParentUnit = un.UnitType.Parent.Units.First();
            //}

            //WorkFlow wf = new WorkFlow(ParentUnit, emp, un);
            //return wf;
            return new WorkFlow();
        }
    }
}
