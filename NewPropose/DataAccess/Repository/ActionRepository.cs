using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewPropose.DataAccess.IRepository;
using NewPropose.Models.Authorization;

namespace NewPropose.DataAccess.Repository
{
    public class ActionRepository : GenericRepository<Actions>, IActionRepository
    {
        public ActionRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}