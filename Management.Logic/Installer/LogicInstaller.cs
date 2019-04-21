using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using Management.ILogic;

namespace Management.Logic.Installer
{
    public class LogicInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IBookLogic>().ImplementedBy<BookLogic>().LifestylePerWebRequest()
                
                );
        }
    }
}
