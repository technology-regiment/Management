
using Background.Common.Cache;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Background.Common.Installer
{
    public class CommonInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ICacheManager>().ImplementedBy<MemoryCacheManager>());
        
            container.Register(Component.For<ITimeSource>().ImplementedBy<DateTimeNowTimeSource>());
        }
    }
}
