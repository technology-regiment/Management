using Castle.Windsor;

namespace Management.Repository.UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork GetCurrentUnitOfWork();
    }

  public  class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IWindsorContainer _container;

        public UnitOfWorkFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public IUnitOfWork GetCurrentUnitOfWork()
        {
             return _container.Resolve<IUnitOfWork>();
        }
    }
}
