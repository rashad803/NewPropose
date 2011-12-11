using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewPropose.Models;

namespace NewPropose.DataAccess.IRepository
{
    public interface IProposalRepository : IRepository<Proposal>
    {
        Proposal Create();
    }
}
