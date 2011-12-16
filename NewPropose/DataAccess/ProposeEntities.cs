using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NewPropose.Models;
using NewPropose.Models.Authorization;
using NewPropose.Models.Units;
using NewPropose.Models.ItemStates.ProplemStates;
using NewPropose.Models.ItemStates.ProposalStates;

namespace NewPropose.DataAccess
{
    public class ProposeEntities : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Inbox> Inboxes { get; set; }
        public DbSet<Outbox> Outboxes { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Actions> Actions { get; set; }
        public DbSet<Controls> Controls { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<OUGroup> OUGroups { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }

        public DbSet<ProblemState> ProblemStates { get; set; }
        public DbSet<ProblemTechnicalCommitteeState> ProblemTechnicalCommitteeStates { get; set; }
        public DbSet<ProblemRegisterState> ProblemRegisterStates { get; set; }
        public DbSet<ProblemCancelState> ProblemCancelStates { get; set; }
        public DbSet<ProblemSuperCommitteeState> ProblemSuperCommitteeStates { get; set; }
        public DbSet<ProblemAcceptedState> ProblemConfirmStates { get; set; }

        public DbSet<ProposalState> ProposalStates { get; set; }
        public DbSet<ProposalRegisterState> ProposalRegisterStates { get; set; }
        public DbSet<ProposalCancelState> ProposalCancelStates { get; set; }
        public DbSet<ProposalSuperCommitteeState> ProposalCommitteeAliStates { get; set; }
        public DbSet<ProposalCommitteeFaniState> ProposalCommitteeFaniStates { get; set; }

        public DbSet<Comment> Comments { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>().HasRequired(emp => emp.Outbox).WithRequiredDependent();
            modelBuilder.Entity<Unit>().HasRequired(unit => unit.Inbox).WithRequiredDependent();
            modelBuilder.Entity<Inbox>().HasRequired(inbox => inbox.Owner).WithRequiredPrincipal();
            

            modelBuilder.Entity<Problem>().Map(m => m.Requires(p => p.States));
            modelBuilder.Entity<Proposal>().Map(m => m.Requires(p => p.States));
            

            base.OnModelCreating(modelBuilder);
        }


    }
}