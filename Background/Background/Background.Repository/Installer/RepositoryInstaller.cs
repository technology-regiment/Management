using Background.Data;
using Background.Repository.UnitOfWork;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Background.Repository.Installer
{
    public class RepositoryInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<IDbContextProvider>()
                       .Where(x => x.Name.EndsWith("Repository"))
                       .WithService.DefaultInterfaces()
                       .LifestyleSingleton());
            container.Register(Component.For<IDbContextProvider>().ImplementedBy<DbContextProvider>().LifestyleSingleton());
            container.Register(Component.For<BackgroundDbContext>().LifestyleSingleton());
            container.Register(Component.For<IUnitOfWorkFactory>().ImplementedBy<UnitOfWorkFactory>().LifestyleSingleton());
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<EntityFrameworkUnitOfWork>().LifestyleSingleton());
        }
    }
}
