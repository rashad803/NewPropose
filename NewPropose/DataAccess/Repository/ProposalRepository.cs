using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewPropose.Models;
using NewPropose.DataAccess.IRepository;
using NewPropose.Models.ItemStates.ProposalStates;

namespace NewPropose.DataAccess.Repository
{
    public class ProposalRepository : GenericRepository<Proposal>, IProposalRepository
    {


        public ProposalRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public Proposal Create()
        {
            var proposal = new Proposal();
            var registerState = new ProposalRegisterState();
            registerState.IsCurrent = true;
            proposal.States.Add(registerState);
            return proposal;
        }
    }
}