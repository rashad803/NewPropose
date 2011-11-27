using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewPropose.DataAccess.IRepository;
using NewPropose.Models;

namespace NewPropose.DataAccess.Repository
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class ,IIdentifier
    {
        protected readonly ProposeEntities RequestDb;
       

        public GenericRepository(IDatabaseFactory databaseFactory)
        {
            this.RequestDb = databaseFactory.Get();
        }     

        public List<TEntity> GetAll()
        {
            return RequestDb.Set<TEntity>().ToList();
        }

        public List<TEntity> GetAllAsNormal()
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAllAsNormal(int pageNo, int pageSize)
        {
            if (pageNo != 0)
                return RequestDb.Set<TEntity>().OrderByDescending(e => e.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            else
                return RequestDb.Set<TEntity>().OrderByDescending(e => e.Id).Take(pageSize).ToList();

        }

        public List<TEntity> GetAllAsNormal(int pageNo, int pageSize, System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return RequestDb.Set<TEntity>().Where(predicate).OrderByDescending(e => e.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<TEntity> GetAllAsNormal(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return RequestDb.Set<TEntity>().Where(predicate).OrderByDescending(e => e.Id).ToList();
        }
        public int GetCount()
        {
            return RequestDb.Set<TEntity>().Count();
        }

        public int GetCount(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return RequestDb.Set<TEntity>().Where(predicate).OrderBy(e => e.Id).Count();
        }

        public List<TEntity> GetListByFilter(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return RequestDb.Set<TEntity>().Where(predicate).OrderBy(e => e.Id).ToList();
        }

        public List<TEntity> GetListByFilter(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, int pageNo, int pageSize)
        {
            return RequestDb.Set<TEntity>().Where(predicate).OrderByDescending(e => e.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
        }

        public TEntity Load(int Id)
        {
            //if (Id != 0)
            return RequestDb.Set<TEntity>().Where(item => item.Id == Id).FirstOrDefault();
            // return RequestDb.Set<TEntity>().Find(Id);//.Where(item => item.Id == Id).FirstOrDefault();// .Find(Id);
            //else
            //    return RequestDb.Set<TEntity>().fin
        }

        //public void Update(TEntity Entity)
        //{
        //    RequestDb.SaveChanges();
        //}

        public virtual void Delete(int Id)
        {
            TEntity item = RequestDb.Set<TEntity>().Find(Id);
            RequestDb.Set<TEntity>().Remove(item);
            //RequestDb.SaveChanges();
        }

        public void Attach(TEntity Entity)
        {
            this.RequestDb.Set<TEntity>().Attach(Entity);
        }


        public void Add(TEntity Entity)
        {
            RequestDb.Set<TEntity>().Add(Entity);
            //RequestDb.SaveChanges();
        }
    }
}