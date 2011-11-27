using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewPropose.Models;
using NewPropose.DataAccess.IRepository;

namespace NewPropose.DataAccess.Repository
{
    public class InboxRepository : GenericRepository<Inbox>, IInboxRepository
    {

        public InboxRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}