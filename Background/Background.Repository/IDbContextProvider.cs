using System;
using Background.Data;
using Castle.Windsor;

namespace Background.Repository
{
    public interface IDbContextProvider : IDisposable
    {
        BackgroundDbContext GetBackgroundDbContext();
    }

    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }
        protected virtual void DisposeCore()
        {
        }
    }

    public class DbContextProvider : Disposable, IDbContextProvider
    {
        private readonly IWindsorContainer _container;

        public DbContextProvider(IWindsorContainer container)
        {
            _container = container;
        }

        public BackgroundDbContext GetBackgroundDbContext()
        {
            return _container.Resolve<BackgroundDbContext>();
        }
    }

}