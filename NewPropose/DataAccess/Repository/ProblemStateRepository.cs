using NewPropose.DataAccess.IRepository;
using NewPropose.Models;

namespace NewPropose.DataAccess.Repository
{
    public class ProblemStateRepository : GenericRepository<ProblemState>, IProblemStateRepository
    {
        public ProblemStateRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}