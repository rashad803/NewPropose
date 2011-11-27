using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPropose.Models.Builder
{
    public class Director
    {
        public static WorkFlow Construct(Unit un, Employee emp)
        {
            IBuilder builder = new FirstBuilder();
            return builder.CreateWorkFlow(un, emp);
        }
    }
}