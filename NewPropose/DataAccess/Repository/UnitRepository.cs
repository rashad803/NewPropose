using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewPropose.Models;
using NewPropose.DataAccess.IRepository;

namespace NewPropose.DataAccess.Repository
{
    public class UnitRepository : GenericRepository<Unit>, IUnitRepository
    {
        private const string TechnicalCommittee = "TechnicalCommittee";
        public UnitRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public IEnumerable<Unit> GetAllTechnicalCommittees()
        {
            return RequestDb.Units.Where(unit => unit.Type == TechnicalCommittee);
        }

        public Unit CreateTechnicalCommittee(string name)
        {
            var unit = new Unit() {Name = name, Type = TechnicalCommittee};
            return unit;
        }
    }
}