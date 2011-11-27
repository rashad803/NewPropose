using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewPropose.Models;
using NewPropose.DataAccess.IRepository;

namespace NewPropose.DataAccess.Repository
{
    public class OutboxRepository : GenericRepository<Outbox>, IOutboxRepository
    {

        public OutboxRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}