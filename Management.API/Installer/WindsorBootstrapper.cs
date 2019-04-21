using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using Management.Logic.Installer;
using Management.Repository.Installer;

namespace Management.WebAPI.Installer
{
    public static class WindsorBootstrapper
    {
        private static IWindsorContainer _container;

        public static void Initialize()
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This(),
                FromAssembly.Containing<RepositoryInstaller>(),
                FromAssembly.Containing<LogicInstaller>()
                );

            _container.Register(Component.For<IWindsorContainer>().Instance(_container).LifestyleSingleton());
        }

        public static IWindsorContainer Container
        {
            get
            {
                return _container;
            }
        }
    }
}