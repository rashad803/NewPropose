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
        private const string SuperCommittee = "SuperCommittee";
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
            var inbox = new Inbox();
            
            var unit = new Unit() {Name = name, Type = TechnicalCommittee};
            inbox.Owner = unit;
            RequestDb.Inboxes.Add(inbox);
            return unit;
        }

        public Unit CreateSuperCommittee(string name)
        {
            var inbox = new Inbox();

            var unit = new Unit() { Name = name, Type = SuperCommittee };
            inbox.Owner = unit;
            RequestDb.Inboxes.Add(inbox);
            return unit;
        }

        public IEnumerable<Unit> GetAllSuperCommittees()
        {
            return RequestDb.Units.Where(unit => unit.Type == SuperCommittee);
        }
    }
}