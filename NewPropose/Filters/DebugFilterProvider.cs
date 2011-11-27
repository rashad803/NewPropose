using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewPropose.Filters
{
    public class DebugFilterProvider : IFilterProvider
    {
        private readonly List<Func<ControllerContext, object>> _conditions = new List<Func<ControllerContext, object>>();
        public void Add(Func<ControllerContext, object> condition)
        {
            _conditions.Add(condition);
        }

        public IEnumerable<System.Web.Mvc.Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            IEnumerable<System.Web.Mvc.Filter> filt = from condition in _conditions
                                                      select condition(controllerContext) into filter
                                                      where filter != null
                                                      select new System.Web.Mvc.Filter(filter, FilterScope.Global, null);
            return filt;
        }

    }
}