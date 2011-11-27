using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace NewPropose.DataAccess.IRepository
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity Entity);        
        List<TEntity> GetAll();
        List<TEntity> GetAllAsNormal();
        List<TEntity> GetAllAsNormal(int pageNo, int pageSize);
        List<TEntity> GetAllAsNormal(int pageNo, int pageSize, Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAllAsNormal(Expression<Func<TEntity, bool>> predicate);
        int GetCount();
        int GetCount(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetListByFilter(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetListByFilter(Expression<Func<TEntity, bool>> predicate, int pageNo, int pageSize);
        TEntity Load(int Id);      
        void Delete(int Id);
        void Attach(TEntity Entity);
    }
}
