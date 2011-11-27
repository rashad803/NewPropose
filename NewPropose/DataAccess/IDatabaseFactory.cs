using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewPropose.DataAccess
{
    public interface IDatabaseFactory : IDisposable
    {
        ProposeEntities Get();
    }
}
