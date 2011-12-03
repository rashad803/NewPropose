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
        private const string TechnicalCommite = "TechnicalCommite";
        public UnitRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public IEnumerable<Unit> GetAllTechnicalCommites()
        {
            return RequestDb.Units.Where(unit => unit.Type == TechnicalCommite);
        }

        public Unit CreateTechnicalCommite(string name)
        {
            var unit = new Unit() {Name = name, Type = TechnicalCommite};
            return unit;
        }
    }
}