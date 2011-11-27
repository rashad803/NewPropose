using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPropose.DataAccess
{
    public class DatabaseFactory : IDatabaseFactory
    {

        private ProposeEntities _database;

        public ProposeEntities Get()
        {
            return _database ?? (_database = new ProposeEntities());
        }
        public void Dispose()
        {
            if (_database != null)
                _database.Dispose();
        }
    }
}