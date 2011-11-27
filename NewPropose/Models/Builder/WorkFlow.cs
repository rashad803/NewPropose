using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewPropose.Models.Builder
{
    public class WorkFlow
    {
        public Unit NextUnit { get; set; }
        public Employee EmployeeHandler { get; set; }
        public Unit UnitHandler { get; set; }

        public WorkFlow() { }

        public WorkFlow(Unit Un, Employee emp, Unit handler)
        {
            EmployeeHandler = emp;
            UnitHandler = handler;
            NextUnit = Un;
        }
        //public string NextState(ItemState CurrentSate)
        //{

        //    if (NextUnit != null)
        //        return NextUnit.UnitType.UnitLevel.ToString();
        //    else
        //        return "Confirm";
        //}
    }
}
