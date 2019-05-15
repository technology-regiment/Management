using System.Collections.Generic;

namespace Background.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity t);
        void Edit(TEntity t);
        void Delete(int id);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
    }
}
