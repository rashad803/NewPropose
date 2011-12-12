using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewPropose.Models;

namespace NewPropose.DataAccess.IRepository
{
    public interface IUnitRepository : IRepository<Unit>
    {
        IEnumerable<Unit> GetAllTechnicalCommittees();
        Unit CreateTechnicalCommittee(string name);
    }
}
