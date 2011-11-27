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
   
        public UnitRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public IEnumerable<Unit> GetAllTechnicalCommites()
        {
            throw new NotImplementedException();
        }
    }
}