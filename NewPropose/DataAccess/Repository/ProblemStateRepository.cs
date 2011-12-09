using System;
using System.Collections.Generic;
using NewPropose.DataAccess.IRepository;
using NewPropose.Models;
using System.Linq;
using NewPropose.Models.ItemStates.ProplemStates;

namespace NewPropose.DataAccess.Repository
{
    public class ProblemStateRepository : GenericRepository<ProblemState>, IProblemStateRepository
    {
        public ProblemStateRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public IEnumerable<Problem> GetProblemsWithRegisterState()
        {
            return RequestDb.ProblemStates.OfType<RegisterState>().Select(s => s.Owner);
        }
    }
}