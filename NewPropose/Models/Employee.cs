using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewPropose.Models.Authorization;

namespace NewPropose.Models
{
    public class Employee : IIdentifier
    {
        public Employee()
        {
            Proposals = new List<Proposal>();
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual Role Role { get; set; }
        public virtual List<Proposal> Proposals { get; set; }
        public virtual List<Comment> Comments { get; set; }

        public virtual Unit Unit { get; set; }

        public virtual int ExecutedProposal { get; set; }

        public virtual EmployeeType EmpLoyeeType { get; set; }

        public virtual string Job { get; set; }
        public virtual string Education { get; set; }

        public virtual string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public void MakeProposal(Problem selectedProblem, Proposal proposal, string subject, string content)
        {
            proposal.Creator = this;
            proposal.Subject = subject;
            proposal.Content = content;
            Proposals.Add(proposal);
            proposal.Problem = selectedProblem;
            selectedProblem.Proposals.Add(proposal);
        }
    }
}