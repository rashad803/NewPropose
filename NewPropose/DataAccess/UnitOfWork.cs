using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPropose.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public void Commit()
        {
            _databaseFactory.Get().SaveChanges();
        }
    }
}