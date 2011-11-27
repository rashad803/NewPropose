using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewPropose.Models;
using NewPropose.DataAccess.IRepository;
using NewPropose.Models.Authorization;

namespace NewPropose.DataAccess.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {


        public RoleRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}