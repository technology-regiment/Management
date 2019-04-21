using Castle.Windsor;
using System.Data.Entity;

namespace Management.Data
{
    public class DataBaseFactory : IDbFactory
    {
        private readonly IWindsorContainer _container;

        public DataBaseFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public DbContext GetContext()
        {
            return _container.Resolve<ManagementContext>();
        }
    }
}
