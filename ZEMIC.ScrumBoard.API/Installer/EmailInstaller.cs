using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ZEMIC.Common;

namespace ZEMIC.ScrumBoard.API.Installer
{
    public class EmailInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
           
            container.Register(Component.For<IEmailService>().ImplementedBy<EmailService>().LifestylePerWebRequest());
        }
    }
}