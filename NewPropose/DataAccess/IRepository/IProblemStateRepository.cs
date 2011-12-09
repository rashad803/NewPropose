using System.Collections.Generic;
using NewPropose.Models;

namespace NewPropose.DataAccess.IRepository
{
    public interface IProblemStateRepository : IRepository<ProblemState>
    {
        IEnumerable<Problem> GetProblemsWithRegisterState();        
    }
}