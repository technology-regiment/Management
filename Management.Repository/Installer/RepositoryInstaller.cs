using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Management.Data;
using Management.IRepository;
using Management.Repository.UnitOfWork;

namespace Management.Repository.Installer
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUnitOfWorkFactory>().ImplementedBy<UnitOfWorkFactory>().LifestylePerWebRequest(),
                Component.For<IUnitOfWork>().ImplementedBy<EntityFrameworkUnitOfWork>().LifestylePerWebRequest(),
                Component.For<IDbFactory>().ImplementedBy<DataBaseFactory>().LifestyleSingleton(),
                Component.For<ManagementContext>().LifestylePerWebRequest(),
                Component.For<IBookRepository>().ImplementedBy<BookRepository>().LifestyleSingleton()
              
                );
        }
    }
}
