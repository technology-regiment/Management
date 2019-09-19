using Background.Common.Installer;
using Background.Logic.Installer;
using Background.Repository.Installer;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Background.API.Installer
{
    public static class WindsorBootstrapper
    {
        private static IWindsorContainer _container;

        public static void Initialize()
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This(),
                FromAssembly.Containing<LogicInstaller>(),
                FromAssembly.Containing<RepositoryInstaller>(),
                FromAssembly.Containing<CommonInstaller>());

            _container.Register(Component.For<IWindsorContainer>().Instance(_container).LifestyleSingleton());
        }

        public static IWindsorContainer Container
        {
            get { return _container; }
        }
    }
}