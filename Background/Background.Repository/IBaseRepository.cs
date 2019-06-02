using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Background.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity t);

        void Edit(TEntity t);
        void Delete(Guid id);
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetPagingData(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize,
           string orderByPropertyName, bool isAsc, out int totalRecordes);
    }
}