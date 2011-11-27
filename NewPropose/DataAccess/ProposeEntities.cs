using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NewPropose.Models;
using NewPropose.Models.Authorization;
using NewPropose.Models.Units;
using NewPropose.Models.ItemStates.ProplemStates;

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
        public DbSet<TechnicalCommitteeState> TechnicalCommitteeStates { get; set; }
        public DbSet<RegisterState> RegisterStates { get; set; }
        public DbSet<CancelState> CancelStates { get; set; }
        public DbSet<SuperCommitteeState> SuperCommitteeStates { get; set; }
        public DbSet<ConfirmState> ConfirmStates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasRequired(emp => emp.Outbox).WithRequiredDependent();
            modelBuilder.Entity<Unit>().HasRequired(unit => unit.Inbox).WithRequiredDependent();

            

            base.OnModelCreating(modelBuilder);
        }
    }
}