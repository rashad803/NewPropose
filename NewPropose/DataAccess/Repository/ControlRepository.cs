using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewPropose.Models.Authorization;
using NewPropose.DataAccess.IRepository;

namespace NewPropose.DataAccess.Repository
{
    public class ControlRepository : GenericRepository<Controls>, IControlRepository
    {
        public ControlRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}