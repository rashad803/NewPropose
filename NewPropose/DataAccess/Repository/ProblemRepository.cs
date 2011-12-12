﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewPropose.Models;
using NewPropose.DataAccess.IRepository;
using NewPropose.Models.ItemStates.ProplemStates;

namespace NewPropose.DataAccess.Repository
{
    public class ProblemRepository : GenericRepository<Problem>, IProblemRepository
    {
        public ProblemRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public Problem Create(Unit unit)
        {
            var problem = new Problem();
            problem.States.Add(new ProblemRegisterState() { IsCurrent = true });
            problem.Creator = unit;
            return problem;
        }

        public IEnumerable<Problem> GetProblemsWithRegisterState()
        {
            return RequestDb.ProblemStates.OfType<ProblemRegisterState>().Select(s => s.Owner);
        }

        public IEnumerable<Problem> GetProblemsWithTechnicalCommitteeState()
        {
            return RequestDb.ProblemStates.OfType<ProblemTechnicalCommitteeState>().Select(s => s.Owner);
        }


        //public IEnumerable<Problem> GetNewProblems()
        //{
        //    var res = RequestDb.RegisterStates.Select(state => state.Owner);
        //    return res;
        //}


        //public IEnumerable<Problem> GetAllForEmployees()
        //{
        //    var res = RequestDb.TechnicalCommitteeStates.Select(state => state.Owner);
        //    return res;
        
        //}
    }
}