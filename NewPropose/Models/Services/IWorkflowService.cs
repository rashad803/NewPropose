using System.Collections.Generic;

namespace NewPropose.Models.Services
{
    public interface IWorkflowService
    {
        IEnumerable<Problem> GetPeopleProblems();
        IEnumerable<Problem> GetNewProblems();
    }
}