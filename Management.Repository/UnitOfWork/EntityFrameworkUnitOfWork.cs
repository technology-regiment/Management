using System;
using System.Data.Entity;
using Management.Data;

namespace Management.Repository.UnitOfWork
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _factory;

        public EntityFrameworkUnitOfWork(IDbFactory factory)
        {
            _factory = factory;
        }

        public void Commit()
        {
            DataContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    DataContext.Dispose();
                }
            }
            this._disposed = true;
        }
        private DbContext DataContext => _factory.GetContext();
    }
}
